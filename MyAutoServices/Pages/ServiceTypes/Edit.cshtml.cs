using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAutoServices.Data;
using MyAutoServices.Models;

namespace MyAutoServices.Pages.ServiceTypes
{
    public class EditModel : PageModel
    {
        #region Constructor
        [BindProperty]
        public ServiceType ServiceType { get; set; } = default!;

        private readonly MyAutoServices.Data.ApplicationDbContext _context;

        public EditModel(MyAutoServices.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiceTypes == null)
            {
                return NotFound();
            }

            var servicetype =  await _context.ServiceTypes.FirstOrDefaultAsync(m => m.ID == id);
            if (servicetype == null)
            {
                return NotFound();
            }
            ServiceType = servicetype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(ServiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(ServiceType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServiceTypeExists(int id)
        {
          return (_context.ServiceTypes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
