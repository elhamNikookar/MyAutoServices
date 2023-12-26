using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Models.ViewModels;

namespace MyAutoService.Pages.Services
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarServiceViewModel CarServiceVM { get; set; }

        public async Task<IActionResult> OnGet(int carId)
        {
            CarServiceVM = new CarServiceViewModel()
            {
                Car = await _context.Cars.Include(c => c.ApplicationUser)
                    .FirstOrDefaultAsync(c => c.ID == carId),
                ServiceHeader = new ServiceHeader()
            };

            List<string> lstServiceTypeInShoppingCart = _context.ServicesShoppingCarts
                .Include(c => c.ServiceType)
                .Where(c => c.CarID == carId)
                .Select(c => c.ServiceType.Name)
                .ToList();

            IQueryable<ServiceType> lstServices = from s in _context.ServiceTypes
                                                  where !(lstServiceTypeInShoppingCart.Contains(s.Name))
                                                  select s;

            CarServiceVM.ServiceTypesList = lstServices.ToList();
            CarServiceVM.ServicesShoppingCarts = _context.ServicesShoppingCarts.Include(c => c.ServiceType)
                .Where(c => c.CarID == carId)
                .ToList();
            CarServiceVM.ServiceHeader.TotalPrice = 0;

            foreach (var item in CarServiceVM.ServicesShoppingCarts)
            {
                CarServiceVM.ServiceHeader.TotalPrice += item.ServiceType.Price;
            }

            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                CarServiceVM.ServiceHeader.DateAdded = DateTime.Now;
                CarServiceVM.ServicesShoppingCarts = _context.ServicesShoppingCarts.Include(c => c.ServiceType)
                    .Where(c => c.CarID == CarServiceVM.Car.ID).ToList();
                foreach (var shop in CarServiceVM.ServicesShoppingCarts)
                {
                    CarServiceVM.ServiceHeader.TotalPrice += shop.ServiceType.Price;
                }

                CarServiceVM.ServiceHeader.CarID = CarServiceVM.Car.ID;
                _context.ServiceHeaders.Add(CarServiceVM.ServiceHeader);
                await _context.SaveChangesAsync();

                foreach (var shop in CarServiceVM.ServicesShoppingCarts)
                {
                    ServiceDetails details = new ServiceDetails()
                    {
                        ServiceHeaderID = CarServiceVM.ServiceHeader.ID,
                        ServiceName = shop.ServiceType.Name,
                        ServicePrice = shop.ServiceType.Price,
                        ServiceTypeID = shop.ServiceTypeID
                    };
                    _context.ServiceDetails.Add(details);
                }
                _context.ServicesShoppingCarts.RemoveRange(CarServiceVM.ServicesShoppingCarts);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cars/Index", new { userId = CarServiceVM.Car.UserID });
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCart()
        {
            ServicesShoppingCart shopping = new ServicesShoppingCart()
            {
                CarID = CarServiceVM.Car.ID,
                ServiceTypeID = CarServiceVM.ServiceDetails.ServiceTypeID
            };
            _context.ServicesShoppingCarts.Add(shopping);
            await _context.SaveChangesAsync();
            return RedirectToPage("Create", new { carId = CarServiceVM.Car.ID });
        }

        public async Task<IActionResult> OnPostRemoveFromCart(int serviceTypeId)
        {
            ServicesShoppingCart shopping = _context.ServicesShoppingCarts
                .First(u => u.CarID == CarServiceVM.Car.ID && u.ServiceTypeID == serviceTypeId);
            _context.Remove(shopping);
            await _context.SaveChangesAsync();
            return RedirectToPage("Create", new { carId = CarServiceVM.Car.ID });
        }

    }
}
