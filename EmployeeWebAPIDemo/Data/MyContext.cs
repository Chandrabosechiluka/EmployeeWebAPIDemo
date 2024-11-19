using EmployeeWebAPIDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EmployeeWebAPIDemo.Data
{
    public class MyContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        

    }
}
