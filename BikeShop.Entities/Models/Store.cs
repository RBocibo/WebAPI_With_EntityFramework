using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Models
{
    [Table("Store")]
    public class Store
    {
        [Key]
        [Required]
        public int StoreId { get; set; }
        [Required]
        public string StoreName { get; set; }  = string.Empty;
        public int Contacts { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public Product? Product { get; set; }
        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
    }
}
