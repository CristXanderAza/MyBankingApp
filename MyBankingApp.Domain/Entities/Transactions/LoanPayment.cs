using MyBankingApp.Domain.Entities.Loans;

namespace MyBankingApp.Domain.Entities.Transactions
{
    public class LoanPayment : BankTransaction
    {
        public Guid LoanID { get; private set; }
        public virtual Loan Loan { get; private set; }

        public LoanPayment(Guid accountID,TransactionTypes type, Guid accountId, decimal amount, string description, Guid loanID)
            : base(TransactionTypes.LoanPayment, accountID, amount, description, null)
        {
            LoanID = loanID;
        }
    }
}