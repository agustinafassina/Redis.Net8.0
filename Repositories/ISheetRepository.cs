using Redis.Net8.Models;

namespace Redis.Net8.Repository
{
    public interface ISheetRepository
    {
        IEnumerable<Sheet> GetAllSheet();
        Sheet? GetSheetById(string id);
        void AddSheet(Sheet sheet);
        Sheet? UpdateSheet(Sheet sheet);
        Sheet? DeleteSheet(string id);
    }
}