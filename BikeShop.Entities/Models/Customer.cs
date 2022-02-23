using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; } 
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "A phone number is required.")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string ContactNumber { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Street { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string City { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Province { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Country { get; set; } = string.Empty;
    }
}
