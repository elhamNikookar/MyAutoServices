using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages.ServiceTypes
{
    public class CreateModel : PageModel
    {
        #region Constructor
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _context.ServiceTypes.Add(ServiceType);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("Index");
        }
    }
}
