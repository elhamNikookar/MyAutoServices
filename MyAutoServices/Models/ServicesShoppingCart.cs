using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyAutoService.Models
{
    public class ServicesShoppingCart
    {
        public int ID { get; set; }
        
        public int CarID { get; set; }
        
        public int ServiceTypeID { get; set; }

        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }

        [ForeignKey("ServiceTypeID")]
        public virtual ServiceType ServiceType { get; set; }
    }
}
