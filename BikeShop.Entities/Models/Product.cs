using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Entities.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } = string.Empty;
        public int ModelYear { get; set; }
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("BrandID")]
        public int BrandID { get; set; }      
        public Brand? Brand { get; set; }

        [Required]
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }       
        public Category? Category { get; set; }

    }
}
