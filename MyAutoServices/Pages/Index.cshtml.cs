using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServiceType> ServiceTypes { get; set; }
        public List<Car> Cars { get; set; }
        public void OnGet()
        {
            ServiceTypes = _context.ServiceTypes.ToList();
            Cars = _context.Cars.ToList();
        }
    }
}
