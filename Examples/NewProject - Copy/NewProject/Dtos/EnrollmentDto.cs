using NewProject.Models;

namespace NewProject.Dtos
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
    public class CreateEnDto
    {
        public int EnrollmentId { get; set; }
        public Guid StudentId { get; set; }
        public int CourseId { get; set; }
    }
    public class UpEnDto
    {
        public int EnrollmentId { get; set; }
        public Guid StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
