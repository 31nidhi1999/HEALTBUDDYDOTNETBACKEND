using System.Data;
using Health.Entity;
using HealthBuddyDotnetBE.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthBuddyDotnetBE.Contexts
{
    public class HealhBuddyContext : DbContext
    {

        public HealhBuddyContext(DbContextOptions<HealhBuddyContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<User> Users { get; set; }

        protected  void onModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Hospital)
                .WithMany()
                .HasForeignKey(a => a.HospitalId);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.TimeSlot)
                .WithOne()
                .HasForeignKey<Appointment>(a => a.TimeSlotId);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p=>p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Hospitals)
                .WithMany(h => h.Doctors)
                .UsingEntity(j => j.ToTable("Hospital_Doctor"));

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Patient>(p=>p.UserId);








        }
        

    }
}

