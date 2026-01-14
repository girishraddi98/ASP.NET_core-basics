using System;
using System.Collections.Generic;

namespace StudentsApp
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Marks { get; set; }

        public static void ShowGrade(List<Student> studentslist)
        {
            foreach (Student student in studentslist)
            {
                if (student.Marks >= 80)
                {
                    Console.WriteLine(student.Name+"-Distinction");
                }
            }
        }
        public static void Main()
        {
            List<Student> list = new List<Student>();
            list.Add(new Student { Id = 101, Name = "Abc", Grade = 3, Marks = 67 });
            list.Add(new Student { Id = 102, Name = "Bbc", Grade = 3, Marks = 76 }); 
            list.Add(new Student { Id = 103, Name = "Bbc", Grade = 3, Marks = 89 });
            list.Add(new Student { Id = 104, Name = "Cbc", Grade = 3, Marks = 80 });
            Student.ShowGrade(list);
        }
    }
}