using Microsoft.AspNetCore.Identity; // Required for IdentityUser and IdentityRole
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HealthCheck.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public byte[] AvatarImage { get; set; }

    }
}
