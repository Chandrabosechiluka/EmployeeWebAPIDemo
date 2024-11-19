using EmployeeWebAPIDemo.Models;
using EmployeeWebAPIDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {

                var errors = string.Join("; ",ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                throw new ValidationException($"{errors}");
            }

            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        
    }

}
