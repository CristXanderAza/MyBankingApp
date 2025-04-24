using MyBankingApp.Domain.Entities.Accounts;

namespace MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Accounts
{
    public interface IAccountRepository : IRepositoryBase<AccountBase, Guid>
    {
        Task<IEnumerable<AccountBase>> GetAccountsByCustomerIdAsync(Guid customerId);
        Task<IEnumerable<AccountBase>> GetAccountsByStatusAsync(AccountStatus status);
    }
}
