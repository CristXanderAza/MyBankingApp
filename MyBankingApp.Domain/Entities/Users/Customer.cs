using MyBankingApp.Domain.Base;
using MyBankingApp.Domain.Entities.Accounts;

namespace MyBankingApp.Domain.Entities.Users
{
    public class Customer : UserBase
    {
        public virtual ICollection<AccountBase> Accounts { get; private set; } = new List<AccountBase>();

        public Result<Customer> Create(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            var credential = Credential.Create(email, password);
            if (!credential.IsSuccessful)
                return Result<Customer>.Fail(credential.Message);
            return Result<Customer>.Success(new Customer(firstName, lastName, phoneNumber, email, credential.Data));
        }

        private Customer(string firstName, string lastName, string phoneNumber, string email, Credential credential)
            : base(firstName, lastName, phoneNumber, email, credential) {}
    }
}
