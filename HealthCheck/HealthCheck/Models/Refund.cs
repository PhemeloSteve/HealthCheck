using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheck.Models
{
    public class Refund
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] // For currency
        public decimal Amount { get; set; }

        [Required]
        public DateTime RefundDate { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [StringLength(255)]
        public string RefundTransactionId { get; set; } // From payment gateway
    }
}
