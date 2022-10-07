using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Coworkee.Common
{
    public abstract class AuditEntity<T> : BaseAuditEntity<T>
    {
       
    }
}
