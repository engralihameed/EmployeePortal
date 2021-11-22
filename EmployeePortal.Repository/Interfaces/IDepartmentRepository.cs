using EmployeePortal.Core.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePortal.Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
    }
}
