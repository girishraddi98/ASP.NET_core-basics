namespace NewProject.Dtos
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public Guid InstructorId { get; set; }
    }
    public class CreateCourseDto
    {
        public string Title { get; set; }
        public List<Guid> InstructorId { get; set; }

    }
    public class UpdateCourseDto
        {
            public string Title { get; set; }
            public Guid InstructorId { get; set; }

    }
}
