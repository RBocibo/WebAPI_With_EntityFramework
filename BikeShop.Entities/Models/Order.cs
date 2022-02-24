using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }      
        public Customer? Customer { get; set; }

        [Required]
        [ForeignKey("CustomerID")]
        public int StoreID { get; set; }      
        public Store? Store { get; set; }

    }
}
