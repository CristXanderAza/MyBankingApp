using MyBankingApp.Application.Features.BankingRequests.Accounts;
using MyBankingApp.NetStrategist;

namespace MyBankingApp.Application.Features.BankingRequests
{
    public class ApproveRequestStrategist : Strategist<IApproveRequestStrategy, string>
    {

        public ApproveRequestStrategist(IServiceProvider serviceProvider) : base(serviceProvider) 
        {
            RegisterStrategy("CreateAccount",typeof(CreateAccountAcceptedStrategy));
        }
    }

}
