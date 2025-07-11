using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheck.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [Required]
        public DateTime StartTime { get; set; } // Start of availability slot

        [Required]
        public DateTime EndTime { get; set; } // End of availability slot

        public bool IsAvailable { get; set; } = true; // Can be set to false if doctor is unavailable for this slot

        [StringLength(500)]
        public string Notes { get; set; } // e.g., "Out of office", "Lunch break"
    }
}
