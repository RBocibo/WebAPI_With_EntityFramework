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
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        [Required]
        public int StoreID { get; set; }
        [ForeignKey("CustomerID")]
        public Store? Store { get; set; }

    }
}
