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

        public IList<Request> Request { get;set; }

        public async Task OnGetAsync()
        {
            Request = await _context.Request.ToListAsync();
        }
    }
}
