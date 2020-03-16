using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoordinatingCompany.Data;
using CoordinatingCompany.Models;

namespace CoordinatingCompany.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly CoordinatingCompany.Data.CoordinatingCompanyContext _context;

        public CreateModel(CoordinatingCompany.Data.CoordinatingCompanyContext context)
        {
            _context = context;
            Schools = new SelectList(_context.Schools, nameof(School.Id), nameof(School.Name));
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Request Request { get; set; }
        public SelectList Schools { get; set; }
        public SelectList Courses { get; set; }

        [BindProperty]
        public int SelectedSchoolId { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Request.School = _context.Schools.FirstOrDefault(s => s.Id == SelectedSchoolId);

            _context.Request.Add(Request);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
