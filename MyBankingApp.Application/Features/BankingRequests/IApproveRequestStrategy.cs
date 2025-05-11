using MyBankingApp.Domain.Entities.BankingRequests;


namespace MyBankingApp.Application.Features.BankingRequests
{
    public interface IApproveRequestStrategy
    {
        Task Process(BankRequestBase request);
    }
}
