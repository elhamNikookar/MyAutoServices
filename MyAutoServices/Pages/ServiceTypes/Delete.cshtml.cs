﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Utilities;

namespace MyAutoService.Pages.ServiceTypes
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DeleteModel : PageModel
    {
        private readonly MyAutoService.Data.ApplicationDbContext _context;

        public DeleteModel(MyAutoService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ServiceType ServiceType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiceTypes == null)
            {
                return NotFound();
            }

            var servicetype = await _context.ServiceTypes.FirstOrDefaultAsync(m => m.ID == id);

            if (servicetype == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceType = servicetype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ServiceTypes == null)
            {
                return NotFound();
            }
            var servicetype = await _context.ServiceTypes.FindAsync(id);

            if (servicetype != null)
            {
                ServiceType = servicetype;
                _context.ServiceTypes.Remove(ServiceType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
