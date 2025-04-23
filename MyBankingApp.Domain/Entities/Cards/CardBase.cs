using MyBankingApp.Domain.Base;
using MyBankingApp.Domain.Entities.Users;


namespace MyBankingApp.Domain.Entities.Cards
{
    public abstract class CardBase : AuditEntity
    {
        public Guid CardID { get; private set; }
        public Guid CustomerID { get; private set; }
        public virtual Customer Customer { get; private set; }
                      
    }
}
