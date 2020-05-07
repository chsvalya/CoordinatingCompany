using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoordinatingCompany.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CoordinatingCompany.Data.TeacherManager;

namespace CoordinatingCompany.Pages
{
    public class TeacherRegModel : PageModel
    {
        private readonly CoordinatingCompanyContext _context;

        public TeacherRegModel(CoordinatingCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string EmailInput { get; set; }
        [BindProperty]
        public string PasswordInput { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            ActivateTeacher(EmailInput, PasswordInput, _context);
            return RedirectToPage("/login");
        }
    }
}