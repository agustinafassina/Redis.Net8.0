
# Redis.Net8.0

This is a repository with a net 8.0 api connected to a Redis (in-memory database).

## API Reference

#### Get all items

```http
  GET /api/GetSheets
```

#### Get item

```http
  GET /api/GetSheetById/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |


## Redis settings
In program.cs change the connectionString:
```
ConnectionMultiplexer.Connect(("localhost:6379")));
```

## Medium article
https://medium.com/@agustinafassina_92108/install-redis-on-ubuntu-server-22-04-ec2-aws-b48254ca3ac5 


