using MyBankingApp.Domain.Entities.Accounts;
using MyBankingApp.Domain.Entities.BankingRequests.Accounts;

namespace MyBankingApp.Application.Features.Accounts.AccountCreation
{
    public interface IAccountCreationStrategy
    {
        Task<AccountBase> CreateAccount(CreateAccountRequest createAccountRequest);
    }
}
