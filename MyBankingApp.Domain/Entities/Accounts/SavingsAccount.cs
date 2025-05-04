
namespace MyBankingApp.Domain.Entities.Accounts
{
    public class SavingsAccount : AccountBase
    {
        public decimal InterestRate { get; private set; }
        public DateTime LastInterestApplied { get; private set; }

        public SavingsAccount(Guid customerId, decimal interestRate) : base(customerId, AccountType.Savings)
        {
            InterestRate = interestRate;
            LastInterestApplied = DateTime.UtcNow;
        }

        public override bool CanDeposit(decimal amount)
            => (amount > 0);
        
        public override bool CanWithdraw(decimal amount)
            => (amount > 0 && amount <= Balance);
        
        public void ApplyInterest()
        {
            if (DateTime.UtcNow.Date > LastInterestApplied.Date.AddDays(30))
            {
                var interest = Balance * (InterestRate / 100);
                Balance += interest;
                LastInterestApplied = DateTime.UtcNow;
            }
        }
    }
}
