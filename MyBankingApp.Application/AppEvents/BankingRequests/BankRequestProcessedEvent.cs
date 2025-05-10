using MediatR;
using MyBankingApp.Application.Features.BankingRequests.RequestStrategies;
using MyBankingApp.Domain.Entities.BankingRequests;
using MyBankingApp.NetStrategist;

namespace MyBankingApp.Application.AppEvents.BankingRequests
{
    public class BankRequestProcessedEvent : INotification
    {
        public required BankRequestBase BankRequest { get; set; }
        public string RequestType => BankRequest.RequestType;
        public BankRequestStatus Status => BankRequest.Status;
    }

    public class BankRequestProcessedEventHandler : INotificationHandler<BankRequestProcessedEvent>
    {

        private readonly IStrategistFor<IAcceptedRequestStrategy, string> _aceptedRequestStrategist;

        public BankRequestProcessedEventHandler(IStrategistFor<IAcceptedRequestStrategy, string> processedRequestStrategist)
        {
            _aceptedRequestStrategist = processedRequestStrategist;
        }

        public async Task Handle(BankRequestProcessedEvent notification, CancellationToken cancellationToken)
        {
            switch (notification.Status)
            {
                case BankRequestStatus.Approved:
                    await _aceptedRequestStrategist.GetStrategy(notification.RequestType).Process(notification.BankRequest);
                    break;
            }
        }
    }
}
