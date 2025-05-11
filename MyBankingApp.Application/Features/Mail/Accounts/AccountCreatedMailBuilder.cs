using MyBankingApp.Application.AppEvents.BankingRequests;
using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.BankingRequests.Accounts;
using MyBankingApp.Domain.Entities.Mails;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Users;

namespace MyBankingApp.Application.Features.Mail.Accounts
{
    public class AccountCreatedMailBuilder : IMailBuilder<AcceptedRequestEvent<CreateAccountRequest>>
    {
        private readonly IUserRepository _userRepository;

        public AccountCreatedMailBuilder(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<MailData> Build(AcceptedRequestEvent<CreateAccountRequest> req, object? arg = null)
        {
            string customerEmail = await _userRepository.GetEmailOfCustomerAsync(req.Request.CustomerId);
            if(arg == null)
                throw new InvalidOperationException("AccountCreatedMailBuilder received null argument. The Account must be sended as argument");
            if (arg is not CreateAccountRequest createAccountRequest)
                throw new InvalidOperationException("AccountCreatedMailBuilder received incompatible argument type. The Account (AccountBase) must be sended as argument");
            AccountBase accountBase = arg as AccountBase;
            MailData message = new MailData
            {
                To = customerEmail,
                Subject = "Account Created",
                Body = $"Your account (#{accountBase.AccountID}) of type {createAccountRequest.AccountType} has been created successfully with an initial deposit of {createAccountRequest.InitialDeposit}.",
            };
            return message;
        }
    }
}
