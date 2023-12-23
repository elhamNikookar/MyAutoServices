using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace MyAutoService.Models
{
    public class ServiceType
    {

        public int ID { get; set; }

        [Display(Name="عنوان")]
        [Required(ErrorMessage ="لطفا نام را وارد کنید.")]
        [MaxLength(300)]
        public string Name { get; set; }

        [Display(Name ="قیمت")]
        [Required(ErrorMessage = "لطفا قیمت را وارد کنید.")]
        public double Price { get; set; }
    }
}
