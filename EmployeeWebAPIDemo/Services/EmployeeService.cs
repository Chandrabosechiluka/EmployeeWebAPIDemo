using EmployeeWebAPIDemo.Exceptions;
using EmployeeWebAPIDemo.Models;
using EmployeeWebAPIDemo.Repositories;

namespace EmployeeWebAPIDemo.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees() => _employeeRepository.GetAll().ToList();

        public Employee GetEmployeeById(Guid id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException($"Employee with ID {id} not found");
            }
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
        }
    }
}
