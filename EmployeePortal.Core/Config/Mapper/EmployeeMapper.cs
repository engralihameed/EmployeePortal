using EmployeePortal.Core.Data.Entities;
using EmployeePortal.Core.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePortal.Core.Config.Mapper
{
    public static class EmployeeMapper
    {
        public static IEnumerable<EmployeeModel> Mapped(IEnumerable<Employee> employees)
        {
            if (employees != null && employees.Count() > 0)
            {
                return employees.Select(e => new EmployeeModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    EmployeeNumber = e.EmployeeNumber,
                    Department = new DepartmentModel()
                    {
                        Id = e.Department.Id,
                        Name = e.Department.Name
                    },
                    JobDescription = e.JobDescription,
                    EmployeeType = new EmployeeTypeModel()
                    {
                        Id = e.EmployeeType.Id,
                        Description = e.EmployeeType.Desription
                    },
                    HourlyPay = e.HourlyPay,
                    Bonus = e.Bonus
                });
            }

            return null;
        }

        public static Employee Mapped(EmployeeModel model)
        {
            if (model != null)
            {
                return new Employee()
                {
                    Id = model.Id,
                    Name = model.Name,
                    EmployeeNumber = model.EmployeeNumber,
                    DepartmentId = model.Department.Id,
                    JobDescription = model.JobDescription,
                    EmployeeTypeId = model.EmployeeType.Id,
                    HourlyPay = model.HourlyPay,
                    Bonus = model.Bonus
                };
            }

            return null;
        }

        public static EmployeeModel Mapped(Employee employee)
        {
            if (employee != null)
            {
                return new EmployeeModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    EmployeeNumber = employee.EmployeeNumber,
                    Department = new DepartmentModel()
                    {
                        Id = employee.Department.Id,
                        Name = employee.Department.Name
                    },

                    JobDescription = employee.JobDescription,
                    EmployeeType = new EmployeeTypeModel()
                    {
                        Id = employee.EmployeeType.Id,
                        Description = employee.EmployeeType.Desription
                    },
                    HourlyPay = employee.HourlyPay,
                    Bonus = employee.Bonus
                };
            }

            return null;
        }
    }
}