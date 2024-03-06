using System;
using System.Collections.Generic;
using HRISApplication.Areas.AddressArea.Models;
using Microsoft.EntityFrameworkCore;

namespace HRISApplication.Models;

public partial class SspdfContext : DbContext
{
    public SspdfContext()
    {
    }

    public SspdfContext(DbContextOptions<SspdfContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Battle> Battles { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<HealthCondition> HealthConditions { get; set; }

    public virtual DbSet<Imprisonment> Imprisonments { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<NextOfKin> NextOfKins { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Spouse> Spouses { get; set; }

    public virtual DbSet<Training> Training { get; set; }
    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<SalaryDetail> SalaryDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //  => optionsBuilder.UseSqlServer("Server=DESKTOP-1019\\SQLEXPRESS;Database=sspdf;Trusted_Connection=True;TrustServerCertificate=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.Boma).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Counuty).HasMaxLength(50);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Payam).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Address)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Address_PersonalDetail");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.ToTable("Assignment");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.PositionHeld).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Assignment_PersonalDetail");
        });

        modelBuilder.Entity<Battle>(entity =>
        {
            entity.ToTable("Battle");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.PlaceOfBattle).HasMaxLength(50);
            entity.Property(e => e.TypeOfInjury).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Battles)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Battle_PersonalDetail");
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity.ToTable("Child");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Occupation).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Children)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Child_PersonalDetail");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollment");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.PlaceOfEnrollment).HasMaxLength(50);
            entity.Property(e => e.ServiceOutsideSspdf).HasColumnName("ServiceOutsideSSPDF");

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Enrollment_PersonalDetail");
        });

        modelBuilder.Entity<HealthCondition>(entity =>
        {
            entity.ToTable("HealthCondition");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.DegreeOfHealthProblem).HasMaxLength(50);
            entity.Property(e => e.HaveAhealthCondition).HasColumnName("HaveAHealthCondition");
            entity.Property(e => e.IfYesExplain).HasMaxLength(50);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.HealthConditions)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HealthCondition_PersonalDetail");
        });

        modelBuilder.Entity<Imprisonment>(entity =>
        {
            entity.ToTable("Imprisonment");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.ExplainTheReason).HasMaxLength(50);
            entity.Property(e => e.ForHowLong).HasMaxLength(50);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Place).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Imprisonments)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Imprisonment_PersonalDetail");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.FluencyLevel).HasMaxLength(50);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Languages)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Language_PersonalDetail");
        });

        modelBuilder.Entity<NextOfKin>(entity =>
        {
            entity.ToTable("NextOfKin");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Occupation).HasMaxLength(50);
            entity.Property(e => e.TelephoneNo).HasMaxLength(13);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.NextOfKins)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_NextOfKin_PersonalDetail");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.ToTable("Parent");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.HelpProvided).HasMaxLength(50);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Occupation).HasMaxLength(50);
            entity.Property(e => e.Parent1)
                .HasMaxLength(50)
                .HasColumnName("Parent");

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Parents)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Parent_PersonalDetail");
        });

        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasKey(e => e.MilitaryNo).HasName("PK_PersonalDetail_1");

            entity.ToTable("PersonalDetail");

            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.BloodGroup).HasMaxLength(50);
            entity.Property(e => e.Ethnicity).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MaritalStatus).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.ProfilePicture).HasColumnType("image");
            entity.Property(e => e.SoldierRank).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50); 
            
            
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.ToTable("Promotion");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.SoldierRank).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Promotion_PersonalDetail");
        });

        modelBuilder.Entity<PersonalFile>(entity =>
        {
            entity.ToTable("PersonalFile");
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            entity.Property(e => e.CreateBy);
            entity.Property(e => e.Location);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Name);
            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.PersonalFile)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PersonalFile_PersonalDetail");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.ToTable("School");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.CertificateAcquired).HasMaxLength(50);
            entity.Property(e => e.FieldOfTraining).HasMaxLength(50);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Place).HasMaxLength(50);
            entity.Property(e => e.SchoolLevel).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Schools)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_School_PersonalDetail");
        });

        modelBuilder.Entity<Spouse>(entity =>
        {
            entity.ToTable("Spouse");

            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.County).HasMaxLength(50);
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Occupation).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Spouses)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Spouse_PersonalDetail");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.Place).HasMaxLength(50);
            entity.Property(e => e.TrainingCenter).HasMaxLength(50);
            entity.Property(e => e.TrainingType).HasMaxLength(50);

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.Training)
                .HasForeignKey(d => d.MilitaryNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Training_PersonalDetail");
        });
        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<SalaryDetail>(entity =>
        {
            entity.ToTable("SalaryDetail");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.BasicPay).HasColumnType("money");
            entity.Property(e => e.Cola).HasColumnType("money");
            entity.Property(e => e.GrossTotal).HasColumnType("money");
            entity.Property(e => e.HouseAllowance).HasColumnType("money");
            entity.Property(e => e.MilitaryNo).HasMaxLength(50);
            entity.Property(e => e.NetPay).HasColumnType("money");
            entity.Property(e => e.Pension).HasColumnType("money");
            entity.Property(e => e.Pit).HasColumnType("money").HasColumnName("PIT");
            entity.Property(e => e.RepresentationAllowance).HasColumnType("money");
            entity.Property(e => e.ResponsibiltyAllowance).HasColumnType("money");
            entity.Property(e => e.TotalDeduction).HasColumnType("money");

            entity.HasOne(d => d.MilitaryNoNavigation).WithMany(p => p.SalaryDetail)
               .HasForeignKey(d => d.MilitaryNo)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_SalaryDetails_PersonalDetail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<HRISApplication.Models.PersonalFile> PersonalFile { get; set; } = default!;
}
