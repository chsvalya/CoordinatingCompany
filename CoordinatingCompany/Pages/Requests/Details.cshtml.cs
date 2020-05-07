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
    public class DetailsModel : PageModel
    {
        private readonly CoordinatingCompany.Data.CoordinatingCompanyContext _context;

        public DetailsModel(CoordinatingCompany.Data.CoordinatingCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignments.Include(a => a.Request).Include(a => a.Request.School).
                Include(a => a.Request.Course).Include(a => a.Request.Course.Department).
                FirstOrDefaultAsync(m => m.Id == id);


            if (Assignment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignments.FindAsync(id);

            if (Assignment != null)
            {
                Assignment.Status = Status.TeacherApprove;
                Assignment.Teacher = await _context.Teachers.FirstAsync(t => t.Email == TempData.Peek("email").ToString());
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
