﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly CoordinatingCompany.Data.CoordinatingCompanyContext _context;

        public DeleteModel(CoordinatingCompany.Data.CoordinatingCompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Request Request { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Request = await _context.Request.FirstOrDefaultAsync(m => m.Id == id);

            if (Request == null)
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

            Request = await _context.Request.FindAsync(id);

            if (Request != null)
            {
                _context.Request.Remove(Request);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
