using Redis.Net8.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.Net8.Repository
{
    public class SheetRepository : ISheetRepository
    {
        private readonly IConnectionMultiplexer _redis;
        public SheetRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public void AddSheet(Sheet sheet)
        {
            if(sheet == null)
            {
                throw new ArgumentOutOfRangeException(nameof(sheet));
            }
            var db = _redis.GetDatabase();
            var serializedSheet = JsonSerializer.Serialize(sheet);
            db.StringSet(sheet.Id, serializedSheet);
        }

        public Sheet? DeleteSheet(string id)
        {
            var db = _redis.GetDatabase();
            var sheet = db.StringGet(id);
            if (sheet.IsNullOrEmpty)
            {
                return null;
            }
            db.KeyDelete(id);
            return JsonSerializer.Deserialize<Sheet>(sheet);
        }

        public IEnumerable<Sheet> GetAllSheet()
        {
            var db = _redis.GetDatabase();

            var sheetKeys = db.Multiplexer.GetServer(_redis.GetEndPoints().First()).Keys(pattern: "sheet:*");

            var sheets = new List<Sheet>();

            foreach (var key in sheetKeys)
            {
                var sheetJson = db.StringGet(key);
                if (!sheetJson.IsNullOrEmpty)
                {
                    var sheet = JsonSerializer.Deserialize<Sheet>(sheetJson);
                    sheets.Add(sheet);
                }
            }

            return sheets;
        }

        public Sheet? GetSheetById(string id)
        {
            var db = _redis.GetDatabase();
            var sheet = db.StringGet(id);
            if(sheet.IsNullOrEmpty)
            {
                return null;
            }
            return JsonSerializer.Deserialize<Sheet>(sheet);
        }

        public Sheet UpdateSheet(Sheet sheet)
        {
            var db = _redis.GetDatabase();

            var id = sheet.Id;
            if (db.KeyExists(id))
            {
                var updatedSheetJson = JsonSerializer.Serialize(sheet);
                db.StringSet(id, updatedSheetJson);
                return sheet;
            }
            else
            {
                return null;
            }
        }
    }
}