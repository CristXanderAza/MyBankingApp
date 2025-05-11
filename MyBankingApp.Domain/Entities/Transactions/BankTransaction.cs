using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Entities.Transactions
{
    public class BankTransaction : AuditEntity
    {
        public Guid TransactionID { get;  set; }
        public DateTime Date { get;  set; }
        public decimal Amount { get;  set; }
        public string Description { get;  set; }
        public TransactionStatus Status { get;  set; } = TransactionStatus.Pending;
        public Guid? FromAccountID { get; set; }
        public Guid? ToAccountID { get; set; }
        public TransactionTypes TransactionType { get; set; }

        public BankTransaction(TransactionTypes type, Guid? fromAccountId, decimal amount, string description, Guid? toAcountId)
        {
            TransactionType = type;
            TransactionID = Guid.NewGuid();
            Date = DateTime.UtcNow;
            Amount = amount;
            Description = description;
            FromAccountID = accountId;
            ToAccountID = toAcountId;
        }

        public BankTransaction() 
        {
            TransactionID = Guid.NewGuid();
            Date = DateTime.UtcNow;
        }
    }
}
