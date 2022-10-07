using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coworkee.Common
{
    public abstract class BaseAuditEntity<T> : BaseEntity, IAuditEntity<T>
    {
        [Column("created_at")]
        public DateTime CreatedAt { get ; set ; }
        [Column("created_by", TypeName = "varchar(18)")]
        public string CreatedBy { get ; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("updated_by", TypeName = "varchar(18)")]
        public string UpdatedBy { get ; set ; }

        public void SetCreated(string userId, DateTime dateTime)
        {
            CreatedBy = userId;
            CreatedAt = dateTime;
            UpdatedBy = userId;
            UpdatedAt = dateTime;
        }

        public void SetUpdated(string userId, DateTime dateTime)
        {
            UpdatedBy = userId;
            UpdatedAt = dateTime;
        }

        public void SyncDateTimeWithUser(TimeZoneInfo timeZoneInfo)
        {
            if (timeZoneInfo == null)
            {
                return;
            }

            CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(CreatedAt, timeZoneInfo);
            UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(UpdatedAt, timeZoneInfo);
        }
    }
}
