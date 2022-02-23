using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; } 
        public Customer? Customer { get; set; }
        [ForeignKey("StoreID")]
        public int StoreID { get; set; }
        public Store? Store { get; set; }

    }
}
