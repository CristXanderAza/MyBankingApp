using MyBankingApp.Domain.Entities.Mails;

namespace MyBankingApp.Application.Features.Mail
{
    public interface IMailBuilder<TRequest>
    {
        Task<MailData> Build(TRequest req, object? arg = null);
    }
}
