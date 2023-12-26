using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyAutoService.Models
{
    public class ServiceDetails
    {
        [Key]
        public int ID { get; set; }

        public int ServiceHeaderID { get; set; }

        [ForeignKey("ServiceHeader")]
        public virtual ServiceHeader Header { get; set; }

        [Display(Name = "سرویس")]
        public int ServiceTypeID { get; set; }

        [ForeignKey("ServiceTypeID")]
        public virtual ServiceType ServiceType { get; set; }

        public double ServicePrice { get; set; }
        public string ServiceName { get; set; }
    }
}
