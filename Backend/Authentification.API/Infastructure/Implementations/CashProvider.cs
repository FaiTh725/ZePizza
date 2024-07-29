using Authentification.API.Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Authentification.API.Infastructure.Implementations
{
    public class CashProvider : ICashProvider
    {
        private readonly IDistributedCache cashe;

        public CashProvider(IDistributedCache cache)
        {
            this.cashe = cache;
        }


        public async Task DeleteData(string key)
        {
            await cashe.RemoveAsync(key);
        }

        public Task DeleteRangeData()
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetData<T>(string key)
        {
            var data = await cashe.GetStringAsync(key);

            if(data == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(data);
        }

        public async Task SetData<T>(string key, T data)
        {
            await cashe.SetStringAsync(key, JsonSerializer.Serialize(data));
        }
    }
}
