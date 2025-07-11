using HealthCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace  HealthCheck.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets for each model
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for currency fields
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Refund>()
                .Property(r => r.Amount)
                .HasColumnType("decimal(18, 2)");

            // Configure many-to-many relationship for Doctor and Specialization
            // This is already handled by the DoctorSpecialization join table, but you can add more explicit configurations if needed.
            // modelBuilder.Entity<DoctorSpecialization>()
            //     .HasKey(ds => new { ds.DoctorId, ds.SpecializationId }); // Composite key if you remove the 'Id' property from DoctorSpecialization

            // Define relationships where foreign keys are present
            // Organization to Doctors, Clerks, Clients
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Doctors)
                .WithOne(d => d.Organization)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Or .Cascade, depending on your business rules

            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Clerks)
                .WithOne(c => c.Organization)
                .HasForeignKey(c => c.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Clients)
                .WithOne(c => c.Organization)
                .HasForeignKey(c => c.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Doctor to Schedules, Appointments
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Schedules)
                .WithOne(s => s.Doctor)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Client to Appointments
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment to Payment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Payment)
                .WithOne(p => p.Appointment)
                .HasForeignKey<Payment>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Payment to Refund
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Refund)
                .WithOne(r => r.Payment)
                .HasForeignKey<Refund>(r => r.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Clerk to Appointments (optional relationship for ApprovedByClerk)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.ApprovedByClerk)
                .WithMany(c => c.ManagedAppointments)
                .HasForeignKey(a => a.ApprovedByClerkId)
                .IsRequired(false) // Make it optional
                .OnDelete(DeleteBehavior.SetNull); // Or .Restrict
        }
    }
}