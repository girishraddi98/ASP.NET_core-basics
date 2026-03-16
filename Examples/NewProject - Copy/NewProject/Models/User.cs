using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProject.Models
{
    public class Student
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string? Token { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Instructor
    {
        public Guid InstructorId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<Course> Courses { get; set; }
        public string? Token { get; set; }
    }
    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public Guid InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
