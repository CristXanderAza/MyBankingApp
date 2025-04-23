using MyBankingApp.Domain.Entities.Cards.Credit;

namespace MyBankingApp.Domain.Entities.Transactions.CreditCardTransactions
{
    public class CreditCardTransaction : BankTransaction
    {
        public Guid CreditCardID { get; private set; }
        public string UsedIn { get; private set; }
        public virtual CreditCard CreditCard { get; private set; }
        public CreditCardTransaction(Guid accountID, Guid accountId, decimal amount, string description, Guid creditCardID, string usedIn)
            : base(TransactionTypes.CreditCard, accountId, amount, description, null)
        {
            CreditCardID = creditCardID;
            UsedIn = usedIn;
        }
    }
    {
    }
}
