using EmployeePortal.Core.Data.Enums;
using System;

namespace EmployeePortal.Core.Data.Entities
{
    public class EmployeeType
    {
        public int Id { get; set; }
        public EmployeeJobType EmployeeJobType { get; set; }
        public string Desription { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
