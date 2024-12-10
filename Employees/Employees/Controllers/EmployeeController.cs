using EmployeeAPI.Model;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee employee;
        public EmployeeController(IEmployee emp)
        {
            employee = emp; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employee.GetAlEmployees());
        }
        [HttpPost("{post}")]
        public IActionResult PostEmployee(EmployeeModel employeeModel) {
            var emp = employee.CreateEmployee(employeeModel);
            return Ok(emp);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = employee.GetEmployeeById(id);
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var emp = employee.DeleteEmployee(id);
            if(emp) return Ok();
            return NotFound("Employee not found");
        }

    
        
    }
}
