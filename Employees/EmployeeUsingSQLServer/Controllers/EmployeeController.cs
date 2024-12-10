using EmployeeUsingSQLServer.Models;
using EmployeeUsingSQLServer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeUsingSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee employee;
        public EmployeeController(IEmployee _emp)
        {
            employee = _emp;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employee.GetAlEmployees());
        }
        [HttpPost]
        public IActionResult PostEmployee(Employee empl)
        {
            var emp = employee.CreateEmployee(empl);
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public IActionResult GetById(Guid id)
        {
            var emp = employee.GetEmployeeById(id);
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var emp = employee.DeleteEmployee(id);
            if (emp) return Ok("Employee Deleted Success");
            return NotFound("Employee not found");
        }
    }
}
