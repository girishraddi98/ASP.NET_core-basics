namespace ExcelToDatabaseAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
    public class StudentDb
    {
        public List<Student> Students = new List<Student>();
        private StudentDb() { 
            Students.Add(new Student { Id = 1, Name = "Alice", Age = 20 });
            Students.Add(new Student { Id = 2, Name = "Bob", Age = 22 });
            Students.Add(new Student { Id = 3, Name = "Charlie", Age = 23 });
            Students.Add(new Student { Id = 4, Name = "Diana", Age = 21 });
            Students.Add(new Student { Id = 5, Name = "Ethan", Age = 24 });
            Students.Add(new Student { Id = 6, Name = "Fiona", Age = 22 });
        }
        public static StudentDb Instance = new StudentDb();
    }
}
