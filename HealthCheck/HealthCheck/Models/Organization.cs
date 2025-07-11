using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace HealthCheck.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        [Phone]
        public string PhoneNumber { get; set; }

        // Foreign key to link to the admin user in the Identity database
        // This assumes the admin is the first user registered for the organization.
        [Required]
        public string AdminApplicationUserId { get; set; } // Stores the Id from ApplicationUser

        // Navigation properties
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Clerk> Clerks { get; set; }
        public ICollection<Client> Clients { get; set; } // Clients who have booked with this organization
    }
}
