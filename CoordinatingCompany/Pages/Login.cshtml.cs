using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CoordinatingCompany.Data.TeacherManager;

namespace CoordinatingCompany.Pages
{
    public class LoginModel : PageModel
    {
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
            if (!ModelState.IsValid || !CheckTeacher(EmailInput, PasswordInput))
            {
                return Page();
            }
            object email = EmailInput;
            TempData["email"] = email;
            return RedirectToPage("Requests/Index");
        }

    }
}