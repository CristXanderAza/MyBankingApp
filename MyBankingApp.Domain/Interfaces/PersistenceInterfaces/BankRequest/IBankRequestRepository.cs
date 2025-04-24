using MyBankingApp.Domain.Entities.BankingRequests;

namespace MyBankingApp.Domain.Interfaces.PersistenceInterfaces.BankRequest
{
    public interface IBankRequestRepository : IRepositoryBase<BankRequestBase, Guid>
    {
        Task<IEnumerable<BankRequestBase>> GetRequestsByCustomerIdAsync(Guid customerId);
        Task<IEnumerable<BankRequestBase>> GetRequestsByStatusAsync(BankRequestStatus status);
       //Task<IEnumerable<BankRequestBase>> GetRequestsByTypeAsync(RequestTypes type);
    }
}
