using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Utilities;

namespace MyAutoService.Pages.ServiceTypes
{
    [Authorize(Roles =SD.AdminEndUser)]
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
