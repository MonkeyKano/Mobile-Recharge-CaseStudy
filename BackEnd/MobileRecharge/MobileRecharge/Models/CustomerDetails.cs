using System.ComponentModel.DataAnnotations;

namespace MobileRecharge.Models
{
    public class CustomerDetails
    {
        [Key]
        public long PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
