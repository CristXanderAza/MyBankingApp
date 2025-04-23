
namespace MyBankingApp.Domain.Entities.Cards.Debit
{
    public class DebitCard : CardBase
    {
        public Guid LinkedAccountID { get; private set; }
        public string CardNumber { get; private set; }
        public DateTime Expiration { get; private set; }
    }
}
