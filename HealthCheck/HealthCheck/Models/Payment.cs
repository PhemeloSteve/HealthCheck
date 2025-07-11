using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheck.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] // For currency
        public decimal Amount { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentMethod Method { get; set; }

        [StringLength(255)]
        public string TransactionId { get; set; } // From payment gateway

        // Indicates if this payment is for priority privileges (deposit)
        public bool IsDeposit { get; set; } = false;

        // Navigation property for refund
        public Refund Refund { get; set; }
    }
}
