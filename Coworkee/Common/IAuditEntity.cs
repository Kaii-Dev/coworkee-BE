using System;

namespace Coworkee.Common
{
    public interface IAuditEntity
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        string UpdatedBy { get; set; }
    }

    public interface IAuditEntity<T>: IAuditEntity
    {
        void SetCreated(string userId , DateTime datetime);
        void SetUpdated(string userId , DateTime datetime);
        void SyncDateTimeWithUser(TimeZoneInfo timeZoneInfo);
    }
}
