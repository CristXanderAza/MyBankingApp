using MyBankingApp.Domain.Base;

namespace MyBankingApp.Domain.Entities.BankingRequests
{
    public abstract class BankRequestBase : AuditEntity
    {
        public Guid RequestId { get;  set; }
        public Guid CustomerId { get;  set; }
        public DateTime RequestedAt { get; set; }
        public BankRequestStatus Status { get; set; }
        public abstract string RequestType { get; }
        public string? RequestDetails { get;  set; }
        public string? AdminComments { get; set; }

        //This property is used to determine if the request was made manually by an admin or by the user through the system.
        public bool IsManual { get; set; }

        protected BankRequestBase(Guid customerId, bool isManual = false)
        {
            RequestId = Guid.NewGuid();
            RequestedAt = DateTime.UtcNow;
            CustomerId = customerId;
            Status = BankRequestStatus.Pending;
            IsManual = isManual;
        }

        public virtual void Approve(string? comments = null)
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
