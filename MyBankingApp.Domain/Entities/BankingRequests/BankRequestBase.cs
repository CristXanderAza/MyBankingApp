using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Entities.BankingRequests
{
    public abstract class BankRequestBase : AuditEntity
    {
        public Guid RequestId { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public DateTime RequestedAt { get; protected set; }
        public BankRequestStatus Status { get; protected set; }

        public string? AdminComments { get; protected set; }

        protected BankRequestBase(Guid customerId)
        {
            RequestId = Guid.NewGuid();
            RequestedAt = DateTime.UtcNow;
            CustomerId = customerId;
            Status = BankRequestStatus.Pending;
        }

        public void Approve(string? comments = null)
        {
            Status = BankRequestStatus.Approved;
            AdminComments = comments;
        }

        public void Reject(string reason)
        {
            Status = BankRequestStatus.Rejected;
            AdminComments = reason;
        }
    }
}
