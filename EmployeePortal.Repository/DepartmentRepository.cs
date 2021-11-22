using EmployeePortal.Core.Data.Entities;
using EmployeePortal.Repository.DataContext;
using EmployeePortal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public DepartmentRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            try
            {
                return
                    await _dbContext.Departments.Select(d => d).ToListAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("unable to retrieve departments", exception);
            }
        }
    }
}
