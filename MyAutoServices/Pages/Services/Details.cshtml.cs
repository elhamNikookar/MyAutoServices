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

namespace MyAutoService.Pages.Services
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ServiceHeader ServiceHeader { get; set; }
        public List<ServiceDetails> ServiceDetailses { get; set; }
        public IActionResult OnGet(int serviceid)
        {
            ServiceHeader = _context.ServiceHeaders
                .Include(s => s.Car)
                .Include(s => s.Car.ApplicationUser)
                .FirstOrDefault(s => s.ID == serviceid);
            if(ServiceHeader==null)
                return NotFound();

            ServiceDetailses = _context.ServiceDetails.Where(d => d.ServiceHeaderID == serviceid).ToList();

            return Page();
        }
    }
}
