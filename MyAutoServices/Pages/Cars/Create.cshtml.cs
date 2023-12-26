using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Utilities;

namespace MyAutoService.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly MyAutoService.Data.ApplicationDbContext _context;

        [BindProperty]
        public Car Car { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImgUp { get; set; }
        public CreateModel(MyAutoService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string userId = null)
        {
            Car = new Car();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            Car.UserID = userId;
            return Page();
        }




        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //var ApplicationUserCar = await _context.Users.FindAsync(Car.UserID);
            //Car.ApplicationUser = (ApplicationUser?)ApplicationUserCar;

            if (!ModelState.IsValid || _context.Cars == null || Car == null)
                return Page();

            if (ImgUp != null)
            {
                Car.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
                string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CarImages", Car.ImageName);
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    ImgUp.CopyTo(fileStream);
                }
            }
            else
            {
                Car.ImageName = SD.DefaultCarImage;
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
