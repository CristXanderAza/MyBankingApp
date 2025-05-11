

namespace MyBankingApp.Application.DTOs.Transactions
{
    public class BankTransactionDTO
    {
        public Guid Id { get; set; }
        public Guid? FromAccountID { get; set; }
        public Guid? ToAccountID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; }
    }
}
