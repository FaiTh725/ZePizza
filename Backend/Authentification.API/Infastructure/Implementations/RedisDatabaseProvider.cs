using Authentification.API.Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackExchange.Redis;
using System.Text.Json;

namespace Authentification.API.Infastructure.Implementations
{
    public class RedisDatabaseProvider : IRedisProvider
    {
        private readonly IDatabase database;

        public RedisDatabaseProvider(IConfiguration configuration)
        {
            var redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"));

            database = redis.GetDatabase();
        }


        public async Task DeleteData(string key)
        {
            var isExist = await database.KeyExistsAsync(key);

            if(isExist)
                await database.KeyDeleteAsync(key);
        }

        public Task DeleteRangeData()
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetData<T>(string key)
        {
            var value = await database.StringGetAsync(key);

            if(string.IsNullOrEmpty(value))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(value!);
        }

        public async Task SetData<T>(string key, T data, DateTimeOffset expirationTime = default)
        {
            var expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);

            await database.StringSetAsync(key, JsonSerializer.Serialize(data),  expirtyTime);
        }
    }
}
