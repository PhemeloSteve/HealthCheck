using HealthCheck.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealtCheck.Data
{
    public class HealthCheckIdentity : IdentityDbContext<ApplicationUser>
    {
        public HealthCheckIdentity(DbContextOptions<HealthCheckIdentity> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Clerk", NormalizedName = "CLERK" },
                new IdentityRole { Id = "3", Name = "Doctor", NormalizedName = "DOCTOR" },
                new IdentityRole { Id = "4", Name = "Client", NormalizedName = "CLIENT" }
            );

            // Seed admin user
            var admin = new ApplicationUser
            {
                Id = "100",
                UserName = "admin@HealthCheck.com",
                NormalizedUserName = "ADMIN@HEALTHCHECK.COM",
                Email = "admin@HealthCheck.com",
                NormalizedEmail = "ADMIN@HEALTHCHECK.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                SecurityStamp = "admin-security-stamp",
                AvatarImage = new byte[0]
            };
            // Password hash for 'Admin@123' (change as needed)
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin@123");
            builder.Entity<ApplicationUser>().HasData(admin);

            // Assign admin role
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "1", UserId = "100" }
            );
        }
    }
}