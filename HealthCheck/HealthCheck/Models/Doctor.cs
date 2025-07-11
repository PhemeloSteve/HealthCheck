using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheck.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }

        // Foreign key to link to the ApplicationUser in the Identity database
        [Required]
        public string ApplicationUserId { get; set; } // Stores the Id from ApplicationUser

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        [Phone]
        public string PhoneNumber { get; set; }

        // Navigation properties
        public ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
