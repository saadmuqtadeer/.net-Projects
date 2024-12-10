using EmployeeUsingSQLServer.Data;
using EmployeeUsingSQLServer.Models;

namespace EmployeeUsingSQLServer.Repository
{
    public class EmployeeRepo : IEmployee

    {
        EmployeeDbContext db;
        public EmployeeRepo(EmployeeDbContext db)
        {
            this.db = db;
        }
        public bool CreateEmployee(Employee model)
        {

            db.Employees.Add(model);
            db.SaveChanges();
            return true;

        }

        public bool DeleteEmployee(Guid id)
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

        public IEnumerable<Employee> GetAlEmployees()
        {
            return db.Employees;
        }

        public Employee GetEmployeeById(Guid id)
        {
            var employee = db.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public Employee UpdateEmployee(Guid id, Employee model)
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

