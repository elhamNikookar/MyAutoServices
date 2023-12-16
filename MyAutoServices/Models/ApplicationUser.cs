using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyAutoService.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(200)]
        public string Name { get; set; }

        public string Address { get; set; }


        [MaxLength(200)]
        public string City { get; set; }


        [MaxLength(200)]
        public string PostalCode { get; set; }

    }
}
