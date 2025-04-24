using MyBankingApp.Domain.Entities.Loans;

namespace MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Loans
{
    public interface ILoanRepository : IRepositoryBase<Loan, Guid>
    {
        Task<IEnumerable<Loan>> GetLoansOfUser(Guid userId);
    }
}
