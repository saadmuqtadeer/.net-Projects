using EmployeeUsingSQLServer.Models;

namespace EmployeeUsingSQLServer.Repository
{
    public interface IEmployee
    {
        public bool CreateEmployee(Employee model);
        public IEnumerable<Employee> GetAlEmployees();
        public Employee GetEmployeeById(Guid id);
        public Employee UpdateEmployee(Guid id, Employee model);
        public bool DeleteEmployee(Guid id);
    }
}
