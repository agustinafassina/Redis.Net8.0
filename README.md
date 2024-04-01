# Redis.Net8.0
This is a repository with a net 8.0 api connected to a Redis (in-memory database).

## Endpoints
GET /GetSheetById
GET /GetSheet
POST /

## Redis settings
In program.cs change the connectionString:
```
ConnectionMultiplexer.Connect(("localhost:6379")));
```

## Medium article
https://medium.com/@agustinafassina_92108/install-redis-on-ubuntu-server-22-04-ec2-aws-b48254ca3ac5 


