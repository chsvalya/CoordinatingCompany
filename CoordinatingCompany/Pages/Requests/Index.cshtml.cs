using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoordinatingCompany.Data;
using CoordinatingCompany.Models;

namespace CoordinatingCompany.Pages.Requests
{
    public class IndexModel : PageModel
    {
        private readonly CoordinatingCompany.Data.CoordinatingCompanyContext _context;

        public IndexModel(CoordinatingCompany.Data.CoordinatingCompanyContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignments { get;set; }
        public Teacher Teacher { get; set; }

        public async Task OnGetAsync()
        {
            Teacher = _context.Teachers.Include(t => t.Department).First(t => t.Email == TempData.Peek("email").ToString());
            Assignments = await _context.Assignments.Include(a => a.Request).Include(a => a.Request.School).
                Include(a => a.Request.Course).Include(a => a.Request.Course.Department).Where(a => 
                a.Request.Course.Department.Name == Teacher.Department.Name).ToListAsync();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("../Login");
        }
    }
}
