using MyBankingApp.Domain.Entities.BankingRequests;

namespace MyBankingApp.Application.Features.BankingRequests.RequestStrategies
{
    public interface IAcceptedRequestStrategy
    {
        Task Process(BankRequestBase bankRequest);
    }
}
