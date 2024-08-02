namespace Authentification.API.Infastructure.Interfaces
{
    public interface IRedisProvider
    {
        Task SetData<T>(string key, T data, DateTimeOffset expirationTime);

        Task<T?> GetData<T>(string key);

        Task DeleteData(string key);

        Task DeleteRangeData();
    }
}
