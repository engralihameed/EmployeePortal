using EmployeePortal.Core.Data.Enums;
using System;

namespace EmployeePortal.Core.Data.Entities
{
    public class EmployeeTypeModel
    {
        public int Id { get; set; }
        public EmployeeJobType EmployeeJobType { get; set; }
        public string Description { get; set; }
    }
}
