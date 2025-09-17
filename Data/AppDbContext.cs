using HealthCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCheck.Data
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

            // Relationships
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Doctors)
                .WithOne(d => d.Organization)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Payment)
                .WithOne(p => p.Appointment)
                .HasForeignKey<Payment>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Refund)
                .WithOne(r => r.Payment)
                .HasForeignKey<Refund>(r => r.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.ApprovedByClerk)
                .WithMany(c => c.ManagedAppointments)
                .HasForeignKey(a => a.ApprovedByClerkId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Data seeding
            modelBuilder.Entity<Organization>().HasData(
                new Organization {
                    Id = 1,
                    Name = "City Health Clinic",
                    Address = "123 Main St, Cityville",
                    Email = "info@cityhealth.com",
                    PhoneNumber = "1112223333",
                    AdminApplicationUserId = "admin-user-1"
                },
                new Organization {
                    Id = 2,
                    Name = "Downtown Medical Center",
                    Address = "456 Center Ave, Downtown",
                    Email = "contact@downtownmed.com",
                    PhoneNumber = "4445556666",
                    AdminApplicationUserId = "admin-user-2"
                }
            );

            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { Id = 1, Name = "Cardiology", Description = "Heart and blood vessel specialist." },
                new Specialization { Id = 2, Name = "Dermatology", Description = "Skin, hair, and nail specialist." },
                new Specialization { Id = 3, Name = "Pediatrics", Description = "Child health specialist." },
                new Specialization { Id = 4, Name = "Neurology", Description = "Brain and nervous system specialist." }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Smith",
                    OrganizationId = 1,
                    ApplicationUserId = "doc-user-1",
                    Email = "alice.smith@clinic.com",
                    PhoneNumber = "1234567890"
                },
                new Doctor {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Jones",
                    OrganizationId = 2,
                    ApplicationUserId = "doc-user-2",
                    Email = "bob.jones@medical.com",
                    PhoneNumber = "2345678901"
                },
                new Doctor {
                    Id = 3,
                    FirstName = "Carol",
                    LastName = "White",
                    OrganizationId = 1,
                    ApplicationUserId = "doc-user-3",
                    Email = "carol.white@clinic.com",
                    PhoneNumber = "3456789012"
                }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    OrganizationId = 1,
                    ApplicationUserId = "client-user-1",
                    Email = "john.doe@email.com",
                    PhoneNumber = "4567890123"
                },
                new Client {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Roe",
                    OrganizationId = 2,
                    ApplicationUserId = "client-user-2",
                    Email = "jane.roe@email.com",
                    PhoneNumber = "5678901234"
                },
                new Client {
                    Id = 3,
                    FirstName = "Sam",
                    LastName = "Green",
                    OrganizationId = 1,
                    ApplicationUserId = "client-user-3",
                    Email = "sam.green@email.com",
                    PhoneNumber = "6789012345"
                }
            );

            modelBuilder.Entity<Clerk>().HasData(
                new Clerk {
                    Id = 1,
                    FirstName = "Clerk",
                    LastName = "One",
                    OrganizationId = 1,
                    ApplicationUserId = "clerk-user-1",
                    Email = "clerk.one@clinic.com",
                    PhoneNumber = "7890123456"
                },
                new Clerk {
                    Id = 2,
                    FirstName = "Clerk",
                    LastName = "Two",
                    OrganizationId = 2,
                    ApplicationUserId = "clerk-user-2",
                    Email = "clerk.two@medical.com",
                    PhoneNumber = "8901234567"
                }
            );

            modelBuilder.Entity<DoctorSpecialization>().HasData(
                new DoctorSpecialization { Id = 1, DoctorId = 1, SpecializationId = 1 },
                new DoctorSpecialization { Id = 2, DoctorId = 2, SpecializationId = 2 },
                new DoctorSpecialization { Id = 3, DoctorId = 3, SpecializationId = 3 }
            );

            modelBuilder.Entity<Appointment>().HasData(

            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment {
                    Id = 1,
                    AppointmentId = 1,
                    Amount = 100.00m,
                    Status = PaymentStatus.Completed,
                    PaymentDate = new DateTime(2025, 9, 17),
                    Method = PaymentMethod.OnlineCard,
                    TransactionId = "TXN1001",
                    IsDeposit = false
                },
                new Payment {
                    Id = 2,
                    AppointmentId = 2,
                    Amount = 150.00m,
                    Status = PaymentStatus.Completed,
                    PaymentDate = new DateTime(2025, 9, 17),
                    Method = PaymentMethod.PayPal,
                    TransactionId = "TXN1002",
                    IsDeposit = false
                }
            );

            modelBuilder.Entity<Refund>().HasData(
                new Refund {
                    Id = 1,
                    PaymentId = 1,
                    Amount = 20.00m,
                    RefundDate = new DateTime(2025, 9, 17),
                    Reason = "Duplicate payment",
                    RefundTransactionId = "REFUND1001"
                }
            );

            modelBuilder.Entity<Schedule>().HasData(
            );
        }
    }
}