using MyBankingApp.Domain.Entities.Mails;

namespace MyBankingApp.Domain.Interfaces.InfraestructureInterfaces.Mail
{
    public interface IMailSender
    {
        Task SendMailAsync(MailData mail);
        Task SendMailWithAttachmentAsync(MailData mail, string attachmentPath);
        Task SendBulkMailAsync(IEnumerable<string> recipients, string subject, string body);
        Task SendMailWithTemplateAsync(string to, string templateName, object model);
    }
}
