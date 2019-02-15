using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StDb2EFRP.Models
{
    public partial class StDb2SqlContext : DbContext
    {
        public StDb2SqlContext()
        {
        }

        public StDb2SqlContext(DbContextOptions<StDb2SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<CoursesOffered> CoursesOffered { get; set; }
        public virtual DbSet<CoursesTaken> CoursesTaken { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Prerequisites> Prerequisites { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=USUARIO\\TEW_SQLEXPRESS;Trusted_Connection=True;MultipleActiveResultSets=true;database=StDb2Sql;");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseNum);

                entity.Property(e => e.CourseNum)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseName).HasMaxLength(50);
            });

            modelBuilder.Entity<CoursesOffered>(entity =>
            {
                entity.HasKey(e => e.CourseNum);

                entity.Property(e => e.CourseNum)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithOne(p => p.CoursesOffered)
                    .HasForeignKey<CoursesOffered>(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesOffered_Courses");
            });

            modelBuilder.Entity<CoursesTaken>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseNum });

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.Snum).HasColumnName("snum");

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithMany(p => p.CoursesTaken)
                    .HasForeignKey(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesTaken_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CoursesTaken)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesTaken_Students");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.CourseNum, e.StudentId });

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Cnum).HasColumnName("CNum");

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Students");
            });

            modelBuilder.Entity<Prerequisites>(entity =>
            {
                entity.HasKey(e => new { e.CourseNum, e.PrereqCnum });

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.PrereqCnum)
                    .HasColumnName("Prereq_Cnum")
                    .HasMaxLength(50);

                entity.Property(e => e.Cnum).HasColumnName("cnum");

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithMany(p => p.PrerequisitesCourseNumNavigation)
                    .HasForeignKey(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prerequisites_Courses");

                entity.HasOne(d => d.PrereqCnumNavigation)
                    .WithMany(p => p.PrerequisitesPrereqCnumNavigation)
                    .HasForeignKey(d => d.PrereqCnum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prerequisites_Courses1");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Major).HasMaxLength(4);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
