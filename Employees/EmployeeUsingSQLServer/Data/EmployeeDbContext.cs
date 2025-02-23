﻿using EmployeeUsingSQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeUsingSQLServer.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
