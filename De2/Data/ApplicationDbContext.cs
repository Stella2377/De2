using De2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace De2.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<StandardPrescription> StandardPrescriptions { get; set; }
    public DbSet<SpecialPrescription> SpecialPrescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cấu hình chiến lược Table Per Type (TPT)
        modelBuilder.Entity<StandardPrescription>().ToTable("StandardPrescriptions");
        modelBuilder.Entity<SpecialPrescription>().ToTable("SpecialPrescriptions");

        // Cấu hình khóa chính cho abstract record
        modelBuilder.Entity<Prescription>().HasKey(p => p.PrescriptionId);
    }
}