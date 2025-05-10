using MyBankingApp.Domain.Entities.Users;

namespace MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Users
{
    public interface IUserRepository : IRepositoryBase<UserBase, Guid>
    {
        Task<UserBase> GetByEmailAsync(string email);
        Task<string> GetEmailOfCustomerAsync(Guid customerId);
    }
}
