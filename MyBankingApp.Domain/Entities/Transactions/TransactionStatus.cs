

namespace MyBankingApp.Domain.Entities.Transactions
{
    public enum TransactionStatus
    {
        Pending,
        Completed,
        Failed,
        Reversed,
        Refunded
    }
}
