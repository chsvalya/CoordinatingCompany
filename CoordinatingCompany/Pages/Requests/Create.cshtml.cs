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

namespace CoordinatingCompany.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly CoordinatingCompany.Data.CoordinatingCompanyContext _context;

        public CreateModel(CoordinatingCompany.Data.CoordinatingCompanyContext context)
        {
            _context = context;
            Schools = new SelectList(_context.Schools, nameof(School.Id), nameof(School.Name));
            Departments = new SelectList(_context.Departments, nameof(Department.Id), nameof(Department.Subject));
            Courses = new SelectList(_context.Courses.Where(c => c.Department.Id == 3), nameof(Course.Id), nameof(Course.Type));
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
        public int SelectedCourseId { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Request.School = _context.Schools.First(s => s.Id == SelectedSchoolId);
            Request.Course = _context.Courses.First(c => c.Department.Id == SelectedDepartmentId
            && _context.Courses.First(c => c.Id == SelectedCourseId).Type == c.Type);
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
