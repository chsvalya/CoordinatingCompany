using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoordinatingCompany.Models;
using System.Web;
using System.Text;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Threading;
using System;
using CoordinatingCompany.Data;
using Microsoft.AspNetCore.Http;

namespace CoordinatingCompany.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly CoordinatingCompanyContext _context;

        public CreateModel(CoordinatingCompanyContext context)
        {
            _context = context;
            Schools = new SelectList(_context.Schools, nameof(School.Id), nameof(School.Name));
            Departments = new SelectList(_context.Departments, nameof(Department.Id), nameof(Department.Subject));
            Courses = new SelectList(Enum.GetValues(typeof(CourseType)).Cast<CourseType>().ToList());
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Request Request { get; set; }
        public SelectList Schools { get; set; }
        public SelectList Departments { get; set; }
        public SelectList Courses { get; set; }

        [BindProperty]
        public int SelectedSchoolId { get; set; }
        [BindProperty]
        public int SelectedDepartmentId { get; set; }
        [BindProperty]
        public CourseType SelectedCourseType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Request.StartDate >= Request.EndDate 
                || Request.StartDate <= DateTime.Now)
            {
                return Page();
            }

            Request.School = _context.Schools.First(s => s.Id == SelectedSchoolId);
            Request.Course = _context.Courses.First(c => c.Department.Id == SelectedDepartmentId
            && SelectedCourseType == c.Type);
            Request.Course.Department = _context.Departments.First(d => d.Id == SelectedDepartmentId);
            _context.Requests.Add(Request);
            _context.Assignments.Add(new Assignment
            {
                Status = Status.Created,
                Request = Request
            });
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
