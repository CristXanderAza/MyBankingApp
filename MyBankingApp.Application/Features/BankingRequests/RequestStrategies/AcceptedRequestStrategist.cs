using MyBankingApp.NetStrategist;

namespace MyBankingApp.Application.Features.BankingRequests.RequestStrategies
{
    public class AcceptedRequestStrategist : Strategist<IAcceptedRequestStrategy, string>
    {
        public AcceptedRequestStrategist(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            RegisterStrategy("CreateAccount", typeof(CreateAccountAcceptedStrategy));
        }
    }
}
