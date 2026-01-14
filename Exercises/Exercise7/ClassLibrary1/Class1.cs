using System.Linq;
namespace ClassLibrary1
{
public class Class1
{
     public class Book
    {
        public string Name { get; set; }
        public int Id { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public double Rating { get; set; }
    }

    public List<Book1> books1 = new()
    {
        new Book1 { Id = 1, Name = "C# Basics", Category = "Programming", Price = 25.99m, Rating = 4.5 },
        new Book1 { Id = 2, Name = "Advanced C#", Category = "Programming", Price = 35.99m, Rating = 4.7 },
        new Book1 { Id = 3, Name = "LINQ in Action", Category = "Programming", Price = 29.99m, Rating = 4.6 },
        new Book1 { Id = 4, Name = "ASP.NET Core", Category = "Web", Price = 39.99m, Rating = 4.8 },
        new Book1 { Id = 5, Name = "Entity Framework", Category = "Database", Price = 31.50m, Rating = 4.4 },
        new Book1 { Id = 6, Name = "SQL Fundamentals", Category = "Database", Price = 22.99m, Rating = 4.3 },
        new Book1 { Id = 7, Name = "Java Basics", Category = "Programming", Price = 24.99m, Rating = 4.2 },
        new Book1 { Id = 8, Name = "Python Crash Course", Category = "Programming", Price = 27.99m, Rating = 4.7 },
        new Book1 { Id = 9, Name = "Data Structures", Category = "Computer Science", Price = 33.99m, Rating = 4.6 },
        new Book1 { Id = 10, Name = "Algorithms Explained", Category = "Computer Science", Price = 34.99m, Rating = 4.8 },
    };

    public List<Book2> books2 = new()
    {
        new Book2 { Id = 11, Name = "Machine Learning Intro", Category = "AI", Price = 44.99m, Rating = 4.5 },
        new Book2 { Id = 12, Name = "Deep Learning", Category = "AI", Price = 49.99m, Rating = 4.7 },
        new Book2 { Id = 13, Name = "Clean Code", Category = "Software Engineering", Price = 37.99m, Rating = 4.9 },
        new Book2 { Id = 14, Name = "Design Patterns", Category = "Software Engineering", Price = 41.99m, Rating = 4.8 },
        new Book2 { Id = 15, Name = "Refactoring", Category = "Software Engineering", Price = 38.99m, Rating = 4.7 },
        new Book2 { Id = 16, Name = "HTML & CSS", Category = "Web", Price = 19.99m, Rating = 4.3 },
        new Book2 { Id = 17, Name = "JavaScript Guide", Category = "Web", Price = 26.99m, Rating = 4.4 },
        new Book2 { Id = 18, Name = "React Basics", Category = "Web", Price = 29.99m, Rating = 4.6 },
        new Book2 { Id = 19, Name = "Angular in Depth", Category = "Web", Price = 32.99m, Rating = 4.5 },
        new Book2 { Id = 20, Name = "Vue.js Essentials", Category = "Web", Price = 28.99m, Rating = 4.4 },
    };

    public class Book1 : Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
    }

    public class Book2 : Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
    }
    
}
}