
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Utilities;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Models.ViewModels;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace MyAutoService.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UsersListViewModel UsersListViewModel { get; set; }

        public async Task<IActionResult> OnGet(int pageId = 1, string searchName = null, string searchEmail = null, string searchPhone = null)
        {
            UsersListViewModel = new UsersListViewModel()
            {
                ApplicationUserList = await _context.ApplicationUsers.ToListAsync(),

            };
            StringBuilder param = new StringBuilder();

            param.Append("/Users?pageId=:");
            param.Append("&searchName=");
            if (searchName != null)
                param.Append(searchName);

            param.Append("&searchEmail=");
            if (searchEmail != null)
                param.Append(searchEmail);

            param.Append("&searchPhone=");
            if (searchPhone != null)
                param.Append(searchPhone);

            if (searchName != null || searchEmail != null || searchPhone != null)
            {
                UsersListViewModel.ApplicationUserList = _context.ApplicationUsers
                    .Where(u => u.Name.Contains(searchName) || u.Email.Contains(searchEmail) || u.PhoneNumber.Contains(searchPhone)).ToList();
            }

            var count = UsersListViewModel.ApplicationUserList.Count;
            UsersListViewModel.PagingInfo = new PagingInfo()
            {
                PageIndex = pageId,
                ItemPerPage = SD.PagingUserCount,
                TotalItems = count,
                UrlParam = param.ToString()
            };
            UsersListViewModel.ApplicationUserList = UsersListViewModel.ApplicationUserList.OrderBy(u => u.Name)
                .Skip((pageId - 1) * SD.PagingUserCount)
                .Take(SD.PagingUserCount).ToList();
            return Page();
        }
    }
}
