namespace P01_HospitalDatabase.Data
{
    using P01_HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class HospitalContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(k => k.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(p => p.HasInsurance)
                .IsRequired(true);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(fk => fk.PatientId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey(fk => fk.PatientId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(fk => fk.PatientId);

            modelBuilder.Entity<Visitation>()
                .HasKey(k => k.VisitationId);

            modelBuilder.Entity<Visitation>()
                .Property(p => p.Date)
                .IsRequired(true);

            modelBuilder.Entity<Visitation>()
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Visitation>()
                .HasOne(v => v.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(fk => fk.PatientId);

            modelBuilder.Entity<Visitation>()
                .HasOne(d => d.Doctor)
                .WithMany(v => v.Visitations)
                .HasForeignKey(fk => fk.DoctorId);

            modelBuilder.Entity<PatientMedicament>()
                .HasKey(k => new { k.PatientId, k.MedicamentId });

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(fk => fk.PatientId);

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(m => m.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(fk => fk.MedicamentId);

            modelBuilder.Entity<Medicament>()
                .HasKey(k => k.MedicamentId);

            modelBuilder.Entity<Medicament>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder.Entity<Medicament>()
                .HasMany(p => p.Prescriptions)
                .WithOne(m => m.Medicament)
                .HasForeignKey(fk => fk.MedicamentId);

            modelBuilder.Entity<Diagnose>()
                .HasKey(k => k.DiagnoseId);

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);

            modelBuilder.Entity<Diagnose>()
                .HasOne(p => p.Patient)
                .WithMany(d => d.Diagnoses)
                .HasForeignKey(fk => fk.PatientId);

            modelBuilder.Entity<Doctor>()
                .HasKey(k => k.DoctorId);

            modelBuilder.Entity<Doctor>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder.Entity<Doctor>()
                .Property(p => p.Specialty)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}
