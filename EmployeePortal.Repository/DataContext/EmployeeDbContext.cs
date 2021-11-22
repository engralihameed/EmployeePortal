using EmployeePortal.Core.Data.Entities;
using EmployeePortal.Core.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeePortal.Repository.DataContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid departmentIdHr = Guid.NewGuid(), departmentIdIT = Guid.NewGuid(), employeeId = Guid.NewGuid();

            modelBuilder.Entity<Employee>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Id = employeeId,
                Name = "John",
                JobDescription="Manager",
                EmployeeNumber="A1001",
                EmployeeTypeId=(int)EmployeeJobType.Permanent ,
                DepartmentId = departmentIdHr,
                Bonus=10,
                HourlyPay=8,
                CreateDateTime = System.DateTime.UtcNow
            });

            modelBuilder.Entity<Department>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Department>().HasData(new Department()
            {
                Id = departmentIdHr,
                Name = "HR",
                CreateDateTime = System.DateTime.UtcNow
            }, new Department()
            {
                Id = departmentIdIT,
                Name = "IT",
                CreateDateTime = System.DateTime.UtcNow
            });

            modelBuilder.Entity<EmployeeType>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<EmployeeType>().HasData(new EmployeeType()
            {
                Id= (int)EmployeeJobType.Permanent,
                EmployeeJobType=EmployeeJobType.Permanent,
                Desription = "Permanent",
                CreateDateTime = System.DateTime.UtcNow
            }, new EmployeeType()
            {
                Id = (int)EmployeeJobType.Contract,
                EmployeeJobType = EmployeeJobType.Contract,
                Desription = "Contract",
                CreateDateTime = System.DateTime.UtcNow
            });
            
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=EmployeePortal.db");

            //optionsBuilder.UseSqlServer("server=.;database=EmployeePortal;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
