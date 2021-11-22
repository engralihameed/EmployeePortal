using System;

namespace EmployeePortal.Core.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
