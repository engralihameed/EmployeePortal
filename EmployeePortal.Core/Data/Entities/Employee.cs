using System;

namespace EmployeePortal.Core.Data.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string EmployeeNumber { get; set; }
        public decimal HourlyPay { get; set; }
        public decimal Bonus  { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
