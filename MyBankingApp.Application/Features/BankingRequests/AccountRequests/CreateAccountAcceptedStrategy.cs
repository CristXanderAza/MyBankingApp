using MyBankingApp.Application.AppEvents.BankingRequests;
using MyBankingApp.Application.Features.Accounts.AccountCreation;
using MyBankingApp.Application.Features.Mail;
using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.BankingRequests;
using MyBankingApp.Domain.Entities.BankingRequests.Accounts;
using MyBankingApp.Domain.Entities.Mails;
using MyBankingApp.Domain.Interfaces.InfraestructureInterfaces.Mail;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Accounts;
using MyBankingApp.Domain.Interfaces.PersistenceInterfaces.Users;
using MyBankingApp.NetStrategist;

namespace MyBankingApp.Application.Features.BankingRequests.AccountRequests
{
    public class CreateAccountAcceptedStrategy : IApproveRequestStrategy
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStrategistFor<IAccountCreationStrategy, AccountType> _accountCreationStrategist;
        private readonly IUserRepository _userRepository;
        private readonly IMailBuilder<AcceptedRequestEvent<CreateAccountRequest>> _mailBuilder;
        private readonly IMailSender _mailSender;

        public CreateAccountAcceptedStrategy(IAccountRepository accountRepository,IStrategistFor<IAccountCreationStrategy, AccountType> accountCreationStrategist, 
            IMailSender mailSender, IUserRepository userRepository, IMailBuilder<AcceptedRequestEvent<CreateAccountRequest>> mailBuilder)
        {
            _accountRepository = accountRepository;
            _accountCreationStrategist = accountCreationStrategist;
            _mailSender = mailSender;
            _userRepository = userRepository;
            _mailBuilder = mailBuilder;
        }

        /*
        public async Task Handle(AcceptedRequestEvent<CreateAccountRequest> notification, CancellationToken cancellationToken)
        {
            CreateAccountRequest createAccountRequest = notification.Request;
            AccountBase accountBase = await _accountCreationStrategist.GetStrategy(createAccountRequest.AccountType)
                .CreateAccount(createAccountRequest);
            await _accountRepository.AddAsync(accountBase);
            MailData message = await _mailBuilder.Build(notification, accountBase);
            await _mailSender.SendMailAsync(message);
        }*/

        public async Task Process(BankRequestBase bankRequest)
        {
            if (bankRequest is not CreateAccountRequest createAccountRequest)
                throw new InvalidOperationException("CreateAccountAcceptedStrategy received incompatible request type.");
            AccountBase accountBase = await _accountCreationStrategist.GetStrategy(createAccountRequest.AccountType)
                .CreateAccount(createAccountRequest);
            await _accountRepository.AddAsync(accountBase);
            var notification = AcceptedRequestEvent<CreateAccountRequest>.Wrap(createAccountRequest);
            MailData message = await _mailBuilder.Build(notification, accountBase);
            await _mailSender.SendMailAsync(message);
        }
    }

}
