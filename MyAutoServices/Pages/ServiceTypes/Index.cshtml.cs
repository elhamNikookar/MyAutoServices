using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages.ServiceTypes
{
    public class IndexModel : PageModel
    {

        #region Constructor
        private readonly ApplicationDbContext _context;
        public IList<ServiceType> ServiceTypes { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task<IActionResult> OnGet()
        {
            ServiceTypes = await _context.ServiceTypes.ToListAsync();
            return Page();
        }
    }
}
