using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Interfaces.InfraestructureInterfaces.Identity
{
    public interface IIdentityServices
    {
        Task<Result<string>> Login(string email, string password);
        Task<Result<Unit>> Register(string email, string password);
    }
}
