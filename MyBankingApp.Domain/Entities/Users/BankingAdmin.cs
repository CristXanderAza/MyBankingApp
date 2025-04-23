using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Entities.Users
{
    public class BankingAdmin : UserBase
    {
        public AdminRole Role { get; set; }

        public static Result<BankingAdmin> Create(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            var credentialResult = Credential.Create(email, password);
            if (!credentialResult.IsSuccessful)
                return Result<BankingAdmin>.Fail(credentialResult.Message);
            var bankingAdmin = new BankingAdmin(firstName, lastName, phoneNumber, credentialResult.Data);
            return Result<BankingAdmin>.Success(bankingAdmin);
        }
        
        public BankingAdmin(string firstName, string lastName, string phoneNumber, Credential credential)
            : base(firstName, lastName,phoneNumber, credential)
        {
        }

    }
}
