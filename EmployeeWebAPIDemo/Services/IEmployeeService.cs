using EmployeeWebAPIDemo.Models;

namespace EmployeeWebAPIDemo.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(Guid id);
        public void AddEmployee(Employee employee);
    }
}
