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

        public DbSet<CoordinatingCompany.Models.Request> Request { get; set; }
    }
}
