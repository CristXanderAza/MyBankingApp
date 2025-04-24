using MyBankingApp.Domain.Entities.Transactions;

namespace MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Transactions
{
    public interface ITransactionRepository : IRepositoryBase<BankTransaction, Guid>
    {
        Task<IEnumerable<BankTransaction>> GetTransactionsByAccountIdAsync(Guid accountId);
        Task<IEnumerable<BankTransaction>> GetTransactionsByCustomerIdAsync(Guid customerId);
        Task<IEnumerable<BankTransaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BankTransaction>> GetTransactionsByTypeAsync(TransactionTypes type);
    }
}

