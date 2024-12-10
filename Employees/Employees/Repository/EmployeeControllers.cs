using EmployeeAPI.Database;
using EmployeeAPI.Model;

namespace EmployeeAPI.Repository
{
    public class EmployeeControllers : IEmployee
    {
        EmployeeDbContext db;
        public EmployeeControllers(EmployeeDbContext db)
        {
            this.db = db;
        }
        public bool CreateEmployee(EmployeeModel model)
        {
            
            db.Employees.Add(model);
            db.SaveChanges();
            return true;

        }

        public bool DeleteEmployee(int id)
        {
            var employee = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return false;
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<EmployeeModel> GetAlEmployees()
        {
            return db.Employees;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            var employee = db.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public EmployeeModel UpdateEmployee(int id, EmployeeModel model)
        {
            var employee = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
            }
            db.SaveChanges();
            return employee;
        }
    }
}
