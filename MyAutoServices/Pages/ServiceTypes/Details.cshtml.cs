using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoServices.Data;
using MyAutoServices.Models;

namespace MyAutoServices.Pages.ServiceTypes
{
    public class DetailsModel : PageModel
    {
        private readonly MyAutoServices.Data.ApplicationDbContext _context;

        public DetailsModel(MyAutoServices.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
