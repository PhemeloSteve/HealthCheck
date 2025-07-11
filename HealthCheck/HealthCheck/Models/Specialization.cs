using System.ComponentModel.DataAnnotations;

namespace HealthCheck.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation property
        public ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
    }
}
