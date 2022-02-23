using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Models
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        [MaxLength(20)]   
        [Required]
        public string  BrandName { get; set; } = string.Empty;
    }
}
