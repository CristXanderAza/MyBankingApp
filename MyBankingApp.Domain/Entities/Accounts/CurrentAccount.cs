using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Entities.Accounts
{
    public class CurrentAccount : AccountBase
    {
        public decimal OverdraftLimit { get; private set; }

        public CurrentAccount(Guid customerId, decimal overdraftLimit) : base(customerId)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override bool CanDeposit(decimal amount)
            => (amount > 0);
        public override bool CanWithdraw(decimal amount)
            => (amount > 0 && amount <= Balance + OverdraftLimit);
        public Result<decimal> SetOverdraftLimit(decimal limit)
        {
            if (limit < 0)
                return Result<decimal>.Fail("Overdraft limit cannot be negative");
            OverdraftLimit = limit;
            return Result<decimal>.Success(limit);
        }
    }
}
