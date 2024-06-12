using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobileRecharge.Models
{
    public class RechargeHistory
    {
        [Key]
        public int RechargeId { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Data { get; set; }
        [Required]
        public string Voice { get; set; }
        [Required]
        public int SMS { get; set; }
        [Required]
        public int Validity { get; set; }
    }
}
