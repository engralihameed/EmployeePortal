using EmployeePortal.Core.Data.Entities;
using System;

namespace EmployeePortal.Core.Data.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string EmployeeNumber { get; set; }
        public decimal HourlyPay { get; set; }
        public decimal Bonus { get; set; }
        public DepartmentModel Department { get; set; }
        public EmployeeTypeModel EmployeeType { get; set; }
    }
}
