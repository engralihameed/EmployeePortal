using EmployeePortal.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePortal.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Guid> Add(Employee employee);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(Guid id);
        Task Update(Employee employee);
        Task Delete(Guid id);
    }
}
