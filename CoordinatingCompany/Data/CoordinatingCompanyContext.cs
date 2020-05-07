using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoordinatingCompany.Models;

namespace CoordinatingCompany.Data
{
    public class CoordinatingCompanyContext : DbContext
    {
        public CoordinatingCompanyContext (DbContextOptions<CoordinatingCompanyContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}
