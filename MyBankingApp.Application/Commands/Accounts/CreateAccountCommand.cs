using MediatR;
using MyBankingApp.Application.DTOs.BankingRequests;
using MyBankingApp.Domain.Base;
using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.BankingRequests.Accounts;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.BankRequest;

namespace MyBankingApp.Application.Commands.Accounts
{
    public class CreateAccountCommand : IRequest<Result<BankRequestDTO>>
    {
        public Guid CustomerId { get; set; }
        public string AccountType { get; set; }
        public decimal InitialDeposit { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? OverdraftLimit { get; set; }
  
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<BankRequestDTO>>
    {
        private readonly IBankRequestRepository _requestRepository;

        public CreateAccountCommandHandler(IBankRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Result<BankRequestDTO>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {            
            if(Enum.TryParse(request.AccountType, out AccountType accountType))
            {
                var createAccountRequest = new CreateAccountRequest(request.CustomerId, accountType, request.InitialDeposit);
                createAccountRequest.UpdateAccountDetails(accountType, request.InitialDeposit);
                await _requestRepository.AddAsync(createAccountRequest);
                BankRequestDTO res = new BankRequestDTO
                {
                    RequestID = Guid.NewGuid(),
                    CustomerID = createAccountRequest.CustomerId,
                    RequestType = createAccountRequest.RequestType,
                    Status = createAccountRequest.Status.ToString(),
                    RequestComments = createAccountRequest.RequestDetails,
                    AdminsComments = createAccountRequest.AdminComments
                };
                return Result<BankRequestDTO>.Success(res);
            }
            else
            {
                return Result<BankRequestDTO>.Fail("Invalid account type.");
            }
        }
    }
}
