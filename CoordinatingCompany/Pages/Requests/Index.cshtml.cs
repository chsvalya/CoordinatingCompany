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
        public string TeacherName { get; set; }

        public async Task OnGetAsync()
        {
            Assignments = await _context.Assignments.Include(a => a.Request).Include(a => a.Request.School).
                Include(a => a.Request.Course).Include(a => a.Request.Course.Department).ToListAsync();
            TeacherName = _context.Teachers.First(t => t.Email == TempData.Peek("email").ToString()).Name;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("../Login");
        }
    }
}
