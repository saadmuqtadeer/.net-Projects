using EmployeeAPI.Model;

namespace EmployeeAPI.Repository
{
    public interface IEmployee
    {
        public bool CreateEmployee(EmployeeModel model);
        public IEnumerable<EmployeeModel> GetAlEmployees();
        public EmployeeModel GetEmployeeById(int id);
        public EmployeeModel UpdateEmployee(int id, EmployeeModel model);
        public bool DeleteEmployee(int id);
    }
}
