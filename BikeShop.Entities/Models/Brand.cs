using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool IsDeleted { get; set; }
    }
}
