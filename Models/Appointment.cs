using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheck.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [Required]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

    [StringLength(500)]
    public string? Reason { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.PendingApproval;

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        // Optional: Clerk who approved/managed this appointment
        public int? ApprovedByClerkId { get; set; }
    [ForeignKey("ApprovedByClerkId")]
    public Clerk? ApprovedByClerk { get; set; }

    // Navigation property for payment
    public Payment? Payment { get; set; }
    }
}
