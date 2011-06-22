using System;

namespace ValueInjector.Models
{
    public interface IAudit
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }

    public interface IAudit<T> : IAudit {}
}