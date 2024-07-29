namespace Authentification.API.Infastructure.Interfaces
{
    public interface ICashProvider
    {
        Task SetData<T>(string key, T data);

        Task<T?> GetData<T>(string key);

        Task DeleteData(string key);

        Task DeleteRangeData();
    }
}
