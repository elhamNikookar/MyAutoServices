using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyAutoService.Models
{
    public class ServiceHeader
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "کیلومتر")]
        public double? Miles { get; set; }

        [Display(Name = "جمع کل")]
        [Required]
        public double TotalPrice { get; set; }

        [Display(Name = "توضیحات")]

        public string? Description { get; set; }

        [Required]
        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "yyyy/MM/dd")]
        public DateTime DateAdded { get; set; }

        public int CarID { get; set; }

        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
    }
}
