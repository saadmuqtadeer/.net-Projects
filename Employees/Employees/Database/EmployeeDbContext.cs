using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Database
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees{ get; set;}
    }
}
