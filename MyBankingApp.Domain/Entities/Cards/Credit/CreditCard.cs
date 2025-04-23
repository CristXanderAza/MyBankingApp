using MyBankingApp.Domain.Entities.Transactions.CreditCardTransactions;

namespace MyBankingApp.Domain.Entities.Cards.Credit
{
    public class CreditCard : CardBase
    {
        public decimal CreditLimit { get; private set; }
        public decimal CurrentDebt { get; private set; }
        public decimal InterestRate { get; private set; }

        public virtual ICollection<CreditCardTransaction> Transactions { get; private set; }

        public bool CanCharge(decimal amount) 
            => (CurrentDebt + amount <= CreditLimit);
    }
}
