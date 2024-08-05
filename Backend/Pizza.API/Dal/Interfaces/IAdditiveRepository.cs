using Pizza.API.Domain.Entities;

namespace Pizza.API.Dal.Interfaces
{
    public interface IAdditiveRepository
    {
        Task<Additive> CreateAdditive(Additive additive);

        IQueryable<Additive> GetAll();

        Task<Additive?> GetById(int id);

        Task DeleteAdditive(Additive additive);
    }
}
