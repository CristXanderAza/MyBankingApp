using MyBankingApp.Domain.Base;
using MyBankingApp.Domain.Entities.Loans;
using MyBankingApp.Domain.Entities.Transactions;
using MyBankingApp.Domain.Entities.Users;

namespace MyBankingApp.Domain.Entities.Accounts
{
    public abstract class AccountBase : AuditEntity
    {
        public Guid AccountID { get; protected set; }
        public AccountType AccountType { get; protected set; }
        public decimal Balance { get; protected set; }
        public Guid CustomerID { get; protected set; }
        public AccountStatus Status { get; set; }
        public virtual Customer Customer { get; protected set; }
        public virtual ICollection<BankTransaction> Ingresses { get; protected set; }
        public virtual ICollection<BankTransaction> Egresses { get; protected set; }
        public virtual ICollection<Loan> Loans { get; protected set; } = new List<Loan>();
        public virtual ICollection<BankTransaction> Transactions
        {
            get
            {
                var transactions = new List<BankTransaction>();
                transactions.AddRange(Ingresses);
                transactions.AddRange(Egresses);
                return transactions;
            }
        }

        protected AccountBase(Guid customerId, AccountType accountType)
        {
            AccountID = Guid.NewGuid();
            CustomerID = customerId;
            AccountType = accountType;
        }

        public abstract bool CanDeposit(decimal amount);
        public abstract bool CanWithdraw(decimal amount);

        public virtual bool AddIngress(BankTransaction transaction)
        {
            if (transaction == null)
                return false;
            Ingresses.Add(transaction);
            Balance += transaction.Amount;
            return true;
        }

        public virtual bool AddEgress(BankTransaction transaction)
        {
            if (transaction == null)
                return false;
            Egresses.Add(transaction);
            Balance -= transaction.Amount;
            return true;
        }

    }
}
