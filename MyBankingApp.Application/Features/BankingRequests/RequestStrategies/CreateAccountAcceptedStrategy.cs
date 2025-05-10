using MyBankingApp.Application.Features.Accounts.AccountCreation;
using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.BankingRequests;
using MyBankingApp.Domain.Entities.BankingRequests.Accounts;
using MyBankingApp.Domain.Entities.Mails;
using MyBankingApp.Domain.Interfaces.InfraestructureInterfaces.Mail;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Accounts;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Users;
using MyBankingApp.NetStrategist;

namespace MyBankingApp.Application.Features.BankingRequests.RequestStrategies
{
    public class CreateAccountAcceptedStrategy : IAcceptedRequestStrategy
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStrategistFor<IAccountCreationStrategy, AccountType> _accountCreationStrategist;
        private readonly IUserRepository _userRepository;
        private readonly IMailSender _mailSender;

        public CreateAccountAcceptedStrategy(IAccountRepository accountRepository,IStrategistFor<IAccountCreationStrategy, AccountType> accountCreationStrategist, 
            IMailSender mailSender, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _accountCreationStrategist = accountCreationStrategist;
            _mailSender = mailSender;
            _userRepository = userRepository;
 
        }

        public async Task Process(BankRequestBase bankRequest)
        {
            if (bankRequest is not CreateAccountRequest createAccountRequest)
                throw new InvalidOperationException("CreateAccountAcceptedStrategy received incompatible request type.");
            AccountBase accountBase = await _accountCreationStrategist.GetStrategy(createAccountRequest.AccountType)
                .CreateAccount(createAccountRequest);
            await _accountRepository.AddAsync(accountBase);
            string customerEmail = await _userRepository.GetEmailOfCustomerAsync(createAccountRequest.CustomerId);
            MailData message = new MailData
            {
                To = customerEmail,
                Subject = "Account Created",
                Body = $"Your account (#{accountBase.AccountID}) of type {createAccountRequest.AccountType} has been created successfully with an initial deposit of {createAccountRequest.InitialDeposit}.",
            };
            await _mailSender.SendMailAsync(message);
        }
    }

}
