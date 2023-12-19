
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Models;
using MyAutoServices.Data;

namespace MyAutoService.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] 
        public List<ApplicationUser> ApplicationUserList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ApplicationUserList = await _context.ApplicationUsers.ToListAsync();
            return Page();
        }
    }
}
