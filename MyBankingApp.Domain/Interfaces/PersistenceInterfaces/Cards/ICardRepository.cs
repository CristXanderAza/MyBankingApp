using MyBankingApp.Domain.Entities.Cards;

namespace MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Cards
{
    public interface ICardRepository : IRepositoryBase<CardBase, Guid>
    {
        Task<IEnumerable<CardBase>> GetCardsOfCustomer(Guid customerId);
    }
}
