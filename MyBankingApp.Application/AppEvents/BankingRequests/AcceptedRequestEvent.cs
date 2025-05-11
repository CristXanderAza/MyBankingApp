using MediatR;
using MyBankingApp.Domain.Entities.BankingRequests;

namespace MyBankingApp.Application.AppEvents.BankingRequests
{
    public class AcceptedRequestEvent<TRequest> : INotification where TRequest : BankRequestBase
    {
        public TRequest Request { get; private set; }

        private AcceptedRequestEvent() { }

        public static AcceptedRequestEvent<TRequest> Wrap(TRequest request)
        {
            if(request.Status != BankRequestStatus.Approved)
                throw new InvalidOperationException("Request must be approved to be wrapped on an AcceptedRequest message.");
            return new AcceptedRequestEvent<TRequest> { Request = request };
        }
    }
}
