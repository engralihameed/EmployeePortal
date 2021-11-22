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
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeTypeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<EmployeeType>> GetAll()
        {
            try
            {
                return
                    await _dbContext.EmployeeTypes.Select(d => d).ToListAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("unable to retrieve employee types", exception);
            }
        }
    }
}
