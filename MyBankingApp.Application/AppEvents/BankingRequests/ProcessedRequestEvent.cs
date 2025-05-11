using MediatR;
using MyBankingApp.Application.Features.BankingRequests;
using MyBankingApp.Domain.Entities.BankingRequests;
using MyBankingApp.NetStrategist;

namespace MyBankingApp.Application.AppEvents.BankingRequests
{
    public class ProcessedRequestEvent : INotification
    {
        public BankRequestBase BankRequest { get; set; }
        public BankRequestStatus Status => BankRequest.Status;
        public string RequestType => BankRequest.RequestType;
    }

    public class ProcessedRequestEventHandler : INotificationHandler<ProcessedRequestEvent>
    {
        private readonly IStrategistFor<IApproveRequestStrategy, string> _strategist;

        public ProcessedRequestEventHandler(IStrategistFor<IApproveRequestStrategy, string> strategist)
        {
            _strategist = strategist;
        }

        public async Task Handle(ProcessedRequestEvent notification, CancellationToken cancellationToken)
        {
           switch(notification.Status)
            {
                case BankRequestStatus.Approved:
                    await _strategist.GetStrategy(notification.RequestType).Process(notification.BankRequest);
                    break;
            }
        }
    }


}
