

namespace MyBankingApp.Domain.Base
{
    public class AuditEntity
    {
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; }

        public AuditEntity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
            IsDeleted = false;
        }
    }
}
