using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{
    public class CoordinatingCompanyContext : DbContext
    {
        public CoordinatingCompanyContext(DbContextOptions<CoordinatingCompanyContext> options) : base(options) { }

        public DbSet<Request> Request { get; set; }
    }
}
