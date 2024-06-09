using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Publishing.Domain.Model.Aggregates;
using AppWeb.HormonalCare.API.Publishing.Domain.Model.Entities;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using AppWeb.HormonalCare.API.StoryClinic.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ExternalReport> ExternalReports { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Publishing Context
        
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        
        builder.Entity<Tutorial>().HasKey(t => t.Id);
        builder.Entity<Tutorial>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(t => t.Summary).HasMaxLength(240);

        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(p => p.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<ImageAsset>("asset_image")
            .HasValue<VideoAsset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");

        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();
        builder.Entity<Tutorial>().HasMany(t => t.Assets);
        
        // Category Relationships
        builder.Entity<Category>()
            .HasMany(c => c.Tutorials)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .HasPrincipalKey(t => t.Id);
        
        // Profiles Context
        
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Image,
            image =>
            {
                image.WithOwner().HasForeignKey("Id");
                image.Property(p => p.Url).HasColumnName("Image");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Gender,
            gender =>
            {
                gender.WithOwner().HasForeignKey("Id");
                gender.Property(p => p.Value).HasColumnName("Gender");
            });
        builder.Entity<Profile>().OwnsOne(p => p.BirthDate,
            birthDate =>
            {
                birthDate.WithOwner().HasForeignKey("Id");
                birthDate.Property(p => p.Value).HasColumnName("BirthDate");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Phone,
            phone =>
            {
                phone.WithOwner().HasForeignKey("Id");
                phone.Property(p => p.Number).HasColumnName("PhoneNumber");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(p => p.Address).HasColumnName("EmailAddress");
            });

        // TypeExam Context

        builder.Entity<TypeExam>().HasKey(t => t.Id);
        builder.Entity<TypeExam>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TypeExam>().OwnsOne(t => t.Name,
            name =>
            {
                name.WithOwner().HasForeignKey("Id");
                name.Property(t => t.TypeName).HasColumnName("TypeExamName");
            });

        // MedicalExam Context

        builder.Entity<MedicalExam>().HasKey(t => t.Id);
        builder.Entity<MedicalExam>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MedicalExam>().OwnsOne(t => t.Name,
            name =>
            {
                name.WithOwner().HasForeignKey("Id");
                name.Property(t => t.ExamName).HasColumnName("MedicalExamName");
            });

        // MedicalExam Relationships
        
        
        builder.Entity<TypeExam>()
            .HasMany(m => m.MedicalExams)
            .WithOne(t => t.TypeExam)
            .HasForeignKey(t => t.TypeExamId)
            .HasPrincipalKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<MedicalRecord.Domain.Model.Aggregates.MedicalRecord>()
            .HasMany(m => m.MedicalExams)
            .WithOne(t => t.MedicalRecord)
            .HasForeignKey(t => t.MedicalRecordId)
            .HasPrincipalKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);
        

        // Patient Context
        builder.Entity<Patient>().HasKey(t => t.Id);
        builder.Entity<Patient>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Patient>().OwnsOne(t => t.TypeofBloodName,
            name =>
            {
                name.WithOwner().HasForeignKey("Id");
                name.Property(t => t.TypeofBloodN).HasColumnName("TypeofBloodName");
            });
        
        
        // ReasonOfConsultation Context

        builder.Entity<ReasonOfConsultation>().HasKey(r => r.Id);
        builder.Entity<ReasonOfConsultation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReasonOfConsultation>().Property(r => r.Description).IsRequired().HasMaxLength(500);
        builder.Entity<ReasonOfConsultation>().Property(r => r.Symptoms).IsRequired().HasMaxLength(500);
        
        //MedicalRecord Context
        
        builder.Entity<MedicalRecord.Domain.Model.Aggregates.MedicalRecord>().HasKey(m => m.Id);
        builder.Entity<MedicalRecord.Domain.Model.Aggregates.MedicalRecord>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MedicalRecord.Domain.Model.Aggregates.MedicalRecord>().Property(m => m.ReasonOfConsultationId).IsRequired();
        
        //Medical  Exam Context
        builder.Entity<MedicalExam>().HasKey(t => t.Id);
        builder.Entity<MedicalExam>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MedicalExam>().OwnsOne(t => t.Name,
            name =>
            {
                name.WithOwner().HasForeignKey("Id");
                name.Property(t => t.ExamName).HasColumnName("MedicalExamName");
            });
        // Prescription Context

        builder.Entity<Prescription>().HasKey(p => p.Id);
        builder.Entity<Prescription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Prescription>().Property(p => p.DoctorId).IsRequired();
        builder.Entity<Prescription>().Property(p => p.PatientId).IsRequired();
        builder.Entity<Prescription>().Property(p => p.PrescriptionDate).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Notes).HasMaxLength(500);

// MedicationType Context

        builder.Entity<MedicationType>().HasKey(mt => mt.Id);
        builder.Entity<MedicationType>().Property(mt => mt.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MedicationType>().Property(mt => mt.TypeName).IsRequired().HasMaxLength(300);

// Medication Context

        builder.Entity<Medication>().HasKey(m => m.Id);
        builder.Entity<Medication>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Medication>().Property(m => m.MedicationTypeId).IsRequired();
        builder.Entity<Medication>().Property(m => m.DrugName).IsRequired().HasMaxLength(300);
        builder.Entity<Medication>().Property(m => m.Quantity).IsRequired();
        builder.Entity<Medication>().Property(m => m.Concentration).IsRequired().HasMaxLength(300);
        builder.Entity<Medication>().Property(m => m.Frequency).IsRequired();
        builder.Entity<Medication>().Property(m => m.Duration).IsRequired().HasMaxLength(300);

// MedicationType Relationships

        builder.Entity<MedicationType>()
            .HasMany(m => m.Medications)
            .WithOne(mt => mt.MedicationType)
            .HasForeignKey(mt => mt.MedicationTypeId)
            .HasPrincipalKey(mt => mt.Id)
            .OnDelete(DeleteBehavior.Cascade);
// Prescription Relationships

        builder.Entity<Prescription>()
            .HasMany(p => p.Medications)
            .WithOne(m => m.Prescription)
            .HasForeignKey(m => m.PrescriptionId)
            .HasPrincipalKey(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
        
        // Treatment Context
        
        builder.Entity<Treatment>().HasKey(t => t.Id);
        builder.Entity<Treatment>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Treatment>().Property(t => t.Description).IsRequired().HasMaxLength(500);
        
        
        // Doctor Context
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Doctor>().OwnsOne(d => d.professionalIdentificationNumber);
        builder.Entity<Doctor>().OwnsOne(d => d.subSpecialty);
        builder.Entity<Doctor>().OwnsOne(d => d.certification);
        builder.Entity<Doctor>().Property(d => d.appointmentFee).IsRequired();
        builder.Entity<Doctor>().OwnsOne(d => d.codeDoctor);
        builder.Entity<Doctor>().Property(d => d.subscriptionId).IsRequired();
        builder.Entity<Doctor>().OwnsOne(d => d.profileId);
        
        // Medical Appointment Context
        
        builder.Entity<MedicalAppointment>().HasKey(m => m.Id);
        builder.Entity<MedicalAppointment>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MedicalAppointment>().OwnsOne(m => m.eventDate);
        builder.Entity<MedicalAppointment>().OwnsOne(m => m.startTime);
        builder.Entity<MedicalAppointment>().OwnsOne(m => m.endTime);
        builder.Entity<MedicalAppointment>().Property(m => m.tittle).IsRequired().HasMaxLength(50);
        builder.Entity<MedicalAppointment>().Property(m => m.description).IsRequired().HasMaxLength(500);
        builder.Entity<MedicalAppointment>().OwnsOne(m => m.doctorEmail);
        builder.Entity<MedicalAppointment>().OwnsOne(m => m.patientEmail);
        
    }
}