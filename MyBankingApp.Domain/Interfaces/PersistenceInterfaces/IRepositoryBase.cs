
namespace MyBankingApp.Domain.Interfaces.PersistenceInterfaces
{
    public interface IRepositoryBase<TEntity, TID>
    {
        Task<TEntity> GetByIdAsync(TID id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> WhereAsync(Func<TEntity, bool> predicate);
        Task<TEntity> FirstOrDefaultAsync(Func<TEntity, bool> predicate);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TID id);
    }
}
