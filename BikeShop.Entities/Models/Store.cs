using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required(ErrorMessage = "A phone number is required.")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public int Contacts { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
       
        public Product? Product { get; set; }
        
    }
}
