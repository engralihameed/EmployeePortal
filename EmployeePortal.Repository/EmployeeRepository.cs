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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Add(Employee employee)
        {
            try
            {
                employee.CreateDateTime = DateTime.UtcNow;
                _dbContext.Employees.Add(employee);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("unable to add employee", exception);
            }
            return employee.Id;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return
                    await _dbContext.Employees.Include(e => e.Department).Include(e => e.EmployeeType).Select(e => e).ToListAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("unable to retrieve employees", exception);
            }
        }

        public async Task<Employee> GetById(Guid id)
        {
            try
            {
                return
                    await _dbContext.Employees.Where(e => e.Id.Equals(id)).Include(e => e.Department).Include(e=>e.EmployeeType).Select(e => e).FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("unable to retrieve employee by id", exception);
            }
        }
        public async Task Update(Employee employee)
        {
            try
            {
                var existingEmployee = await _dbContext.Employees.Where(e => e.Id.Equals(employee.Id)).Select(s => s).FirstOrDefaultAsync();
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.JobDescription = employee.JobDescription;
                    existingEmployee.EmployeeNumber = employee.EmployeeNumber;
                    existingEmployee.DepartmentId = employee.DepartmentId;
                    existingEmployee.EmployeeTypeId = employee.EmployeeTypeId;
                    existingEmployee.HourlyPay = employee.HourlyPay;
                    existingEmployee.Bonus = employee.Bonus;

                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("unable to update employee", exception);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var existingEmployee = await _dbContext.Employees.Where(e => e.Id.Equals(id)).Select(s => s).FirstOrDefaultAsync();
                if (existingEmployee != null)
                    _dbContext.Remove(existingEmployee);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("unable to delete employee", exception);
            }
        }
    }
}
