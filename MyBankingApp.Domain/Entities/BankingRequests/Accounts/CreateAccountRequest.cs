using MyBankingApp.Domain.Entities.Accounts;

namespace MyBankingApp.Domain.Entities.BankingRequests.Accounts
{
    public class CreateAccountRequest : BankRequestBase
    {
        public AccountType AccountType { get;  set; }
        public decimal InitialDeposit { get;  set; }
        public decimal? InterestRate { get; set; }
        public decimal? OverdraftLimit { get; set; }
        public override string RequestType => "CreateAccount";
        public CreateAccountRequest(Guid customerId, AccountType accountType, decimal initialDeposit)
            : base(customerId)
        {
            AccountType = accountType;
            InitialDeposit = initialDeposit;
        }
        public void UpdateAccountDetails(AccountType accountType, decimal initialDeposit)
        {
            AccountType = accountType;
            InitialDeposit = initialDeposit;
        }

        public void Approve(decimal interes, decimal limit, string? comments = null)
        {
            if (AccountType == AccountType.Savings)
            {
                InterestRate = interes;
            }
            else if (AccountType == AccountType.Current)
            {
                OverdraftLimit = limit;
            }

            base.Approve(comments);
        }
    }
}
