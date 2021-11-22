using EmployeePortal.Core.Config.Mapper;
using EmployeePortal.Core.Data.Enums;
using EmployeePortal.Core.Data.Models;
using EmployeePortal.Handler.Factory;
using EmployeePortal.Handler.Interfaces;
using EmployeePortal.Repository.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeePortal.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _employeeTypeRepository = employeeTypeRepository;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAll();
            return View(EmployeeMapper.Mapped(employees));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var employeeTypes = await _employeeTypeRepository.GetAll();
            var departments = await _departmentRepository.GetAll();
            ViewBag.Departments = DepartmentMapper.Mapped(departments);
            ViewBag.EmployeeTypes = EmployeeTypeMapper.Mapped(employeeTypes);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeManagerFactory employeeManagerFactory = new EmployeeManagerFactory();
                IEmployeeManager employeeManager = employeeManagerFactory.GetEmployeeManager((EmployeeJobType)model.EmployeeType.Id);
                model.Bonus=employeeManager.GetBonus();
                model.HourlyPay=employeeManager.GetPay();
                await _employeeRepository.Add(EmployeeMapper.Mapped(model));
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var existingEmployee = await _employeeRepository.GetById(id);

            var employeeTypes = await _employeeTypeRepository.GetAll();
            var departments = await _departmentRepository.GetAll();

            ViewBag.Departments = DepartmentMapper.Mapped(departments);
            ViewBag.EmployeeTypes = EmployeeTypeMapper.Mapped(employeeTypes);

            return View(EmployeeMapper.Mapped(existingEmployee));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeManagerFactory employeeManagerFactory = new EmployeeManagerFactory();
                IEmployeeManager employeeManager = employeeManagerFactory.GetEmployeeManager((EmployeeJobType)model.EmployeeType.Id);
                model.Bonus = employeeManager.GetBonus();
                model.HourlyPay = employeeManager.GetPay();
                await _employeeRepository.Update(EmployeeMapper.Mapped(model));
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeRepository.Delete(id);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await _employeeRepository.GetById(id);
            return View(EmployeeMapper.Mapped(employee));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.StackTrace = exceptionDetails.Error.StackTrace;

            return View("Error");
        }
    }
}
