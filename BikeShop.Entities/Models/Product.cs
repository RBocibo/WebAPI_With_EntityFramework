using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [ForeignKey("BrandID")]
        public int BrandID { get; set; }
        public Brand? Brand { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

    }
}
