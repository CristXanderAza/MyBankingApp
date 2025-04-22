using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Entities.Transactions
{
    public class BankTransaction : AuditEntity
    {
        public Guid TransactionID { get; protected set; }
        public DateTime Date { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Description { get; protected set; }
        public Guid? FromAccountID { get; protected set; }
        public Guid? ToAccountID { get; protected set; }
        public TransactionTypes TransactionType { get; protected set; }

        public BankTransaction(TransactionTypes type, Guid accountId, decimal amount, string description, Guid? toAcountId)
        {
            TransactionType = type;
            TransactionID = Guid.NewGuid();
            Date = DateTime.UtcNow;
            Amount = amount;
            Description = description;
            FromAccountID = accountId;
            ToAccountID = toAcountId;
        }
    }
}
