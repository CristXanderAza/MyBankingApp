using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Entities.Users
{
    public class UserBase : AuditEntity
    {
        public Guid UserID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Credential Credential { get; set; }
        public string Email => Credential.Email;
        protected UserBase(string firstName, string LastName, string PhoneNumber, string email, Credential credential)
        {
            UserID = Guid.NewGuid();
            FirstName = firstName;
            LastName = LastName;
            PhoneNumber = PhoneNumber;
            Credential = credential;
        }

        public bool Authenticate(string password)
            => Credential.Authenticate(password);
    }
}
