using System.ComponentModel.DataAnnotations;

namespace EmployeeUsingSQLServer.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
    }
}
