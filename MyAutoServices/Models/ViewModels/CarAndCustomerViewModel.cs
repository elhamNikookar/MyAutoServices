﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAutoService.Models.ViewModels
{
    public class CarAndCustomerViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Car> Cars { get; set; }


    }
}
