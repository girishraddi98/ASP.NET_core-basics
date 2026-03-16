using Microsoft.EntityFrameworkCore;

using NewProject.Models;

namespace NewProject.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Course { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InstructorId);

                entity.Property(e => e.InstructorId)
                      .HasColumnType("char(36)");

                entity.Property(e => e.Name)
                      .HasColumnType("varchar(255)")
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasColumnType("varchar(255)")
                      .IsRequired();

                entity.Property(e => e.PasswordHash)
                      .HasColumnType("varchar(255)")
                      .IsRequired();
            });
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.HasKey(e => e.StudentId);
            //    entity.Property(e => e.StudentId)
            //          .HasColumnType("char(36)");
            //    entity.Property(e => e.Name)
            //          .HasColumnType("varchar(255)")
            //          .IsRequired();
            //    entity.Property(e => e.Email)
            //          .HasColumnType("varchar(255)")
            //          .IsRequired();
            //});
            //modelBuilder.Entity<Course>(entity =>
            //{
            //    entity.HasKey(e => e.CourseId);
            //    entity.Property(e => e.CourseId)
            //          .HasColumnType("char(36)");
            //    entity.Property(e => e.Title)
            //          .HasColumnType("varchar(255)")
            //          .IsRequired();
            //    entity.HasOne(e => e.Instructor)
            //            .WithMany(i => i.Courses)
            //            .HasForeignKey(e => e.InstructorId);


            //});
            // modelBuilder.Entity<Enrollment>(entity =>
            //{
            //    entity.HasKey(e => e.EnrollmentId);
            //    entity.Property(e => e.EnrollmentId)
            //          .HasColumnType("char(36)");
            //    entity.HasOne(e => e.Student)
            //          .WithMany(s => s.Enrollments)
            //          .HasForeignKey(e => e.StudentId);
            //    entity.HasOne(e => e.Course)
            //          .WithMany(c => c.Enrollments)
            //          .HasForeignKey(e => e.CourseId);
            // });    

        }
    }
}
