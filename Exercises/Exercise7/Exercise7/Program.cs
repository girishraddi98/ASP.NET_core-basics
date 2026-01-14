using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using static ClassLibrary1.Class1;


//public class Program
//{
//    public class Book
//    {
//        public string Name { get; set; }
//        public int Id { get; set; }
//        public string Category { get; set; }
//        public decimal Price { get; set; }
//        public double Rating { get; set; }

//    }
//    List<Book> books = new List<Book>
//    {
//        new Book { Id = 1, Name = "C# Basics", Category = "Programming", Price = 25.99m, Rating = 4.5 },
//        new Book { Id = 2, Name = "Advanced C#", Category = "Programming", Price = 35.99m, Rating = 4.7 },
//        new Book { Id = 3, Name = "LINQ in Action", Category = "Programming", Price = 29.99m, Rating = 4.6 },
//        new Book { Id = 4, Name = "ASP.NET Core", Category = "Web", Price = 39.99m, Rating = 4.8 },
//        new Book { Id = 5, Name = "Entity Framework", Category = "Database", Price = 31.50m, Rating = 4.4 },
//        new Book { Id = 6, Name = "SQL Fundamentals", Category = "Database", Price = 22.99m, Rating = 4.3 },
//        new Book { Id = 7, Name = "Java Basics", Category = "Programming", Price = 24.99m, Rating = 4.2 },
//        new Book { Id = 8, Name = "Python Crash Course", Category = "Programming", Price = 27.99m, Rating = 4.7 },
//        new Book { Id = 9, Name = "Data Structures", Category = "Computer Science", Price = 33.99m, Rating = 4.6 },
//        new Book { Id = 10, Name = "Algorithms Explained", Category = "Computer Science", Price = 34.99m, Rating = 4.8 },
//        new Book { Id = 11, Name = "Machine Learning Intro", Category = "AI", Price = 44.99m, Rating = 4.5 },
//        new Book { Id = 12, Name = "Deep Learning", Category = "AI", Price = 49.99m, Rating = 4.7 },
//        new Book { Id = 13, Name = "Clean Code", Category = "Software Engineering", Price = 37.99m, Rating = 4.9 },
//        new Book { Id = 14, Name = "Design Patterns", Category = "Software Engineering", Price = 41.99m, Rating = 4.8 },
//        new Book { Id = 15, Name = "Refactoring", Category = "Software Engineering", Price = 38.99m, Rating = 4.7 },
//        new Book { Id = 16, Name = "HTML & CSS", Category = "Web", Price = 19.99m, Rating = 4.3 },
//        new Book { Id = 17, Name = "JavaScript Guide", Category = "Web", Price = 26.99m, Rating = 4.4 },
//        new Book { Id = 18, Name = "React Basics", Category = "Web", Price = 29.99m, Rating = 4.6 },
//        new Book { Id = 19, Name = "Angular in Depth", Category = "Web", Price = 32.99m, Rating = 4.5 },
//        new Book { Id = 20, Name = "Vue.js Essentials", Category = "Web", Price = 28.99m, Rating = 4.4 },
//        new Book { Id = 21, Name = "NoSQL Databases", Category = "Database", Price = 34.50m, Rating = 4.3 },
//        new Book { Id = 22, Name = "MongoDB Guide", Category = "Database", Price = 30.99m, Rating = 4.4 },
//        new Book { Id = 23, Name = "PostgreSQL Handbook", Category = "Database", Price = 29.50m, Rating = 4.5 },
//        new Book { Id = 24, Name = "MySQL Mastery", Category = "Database", Price = 27.99m, Rating = 4.2 },
//        new Book { Id = 25, Name = "Database Design", Category = "Database", Price = 36.99m, Rating = 4.6 },
//        new Book { Id = 26, Name = "Cloud Computing", Category = "Cloud", Price = 42.99m, Rating = 4.5 },
//        new Book { Id = 27, Name = "AWS Essentials", Category = "Cloud", Price = 39.99m, Rating = 4.6 },
//        new Book { Id = 28, Name = "Azure Fundamentals", Category = "Cloud", Price = 38.99m, Rating = 4.4 },
//        new Book { Id = 29, Name = "Google Cloud Guide", Category = "Cloud", Price = 37.99m, Rating = 4.3 },
//        new Book { Id = 30, Name = "DevOps Basics", Category = "Cloud", Price = 34.99m, Rating = 4.5 },
//    };

//    public static void Main()
//    {
//        Program program = new Program();
//        var programmingBooks = program.books
//        /*//    .Where(b => b.Price == 39.99m); // Changed from Any to Where to get a collection

//        //foreach (var book in programmingBooks)
//        //{
//        //    Console.WriteLine(); // {book.Name} - {book.Price:C} - Rating: {book.Rating}
//        //}


//        //.Select(b=> b.Category).Where(c=> c=="Programming").
//        //OrderByDescending(c=>c);
//        //foreach (var category in programmingBooks)
//        //{
//        //    Console.WriteLine(category);
//        //}


//        //program.books.Insert(30, new Book { Id = 31, Name = "New Programming Book", Category = "Programming", Price = 30.99m, Rating = 4.5 });

//        //program.books.RemoveAll(b=>b.Id== 31);
//        //foreach (var book in program.books)
//        //{
//        //    Console.WriteLine($"{book.Name} - {book.Price:C} - Rating: {book.Rating}");
//        //}*/

//        .Where(b => b.Category == "Pro________");
//        foreach (var book in programmingBooks)
//        {
//            Console.WriteLine($"{book.Name} - {book.Price:C} - Rating: {book.Rating}");
//        }



//    }
//}
public class Program
{
    public static void Main()
    {
        Class1 obj = new Class1();

        var union = obj.books1.Cast<Book>()
                     .Union(obj.books1.Cast<Book>());

        foreach (var book in union)
        {
            Console.WriteLine(book.Name);
        }
     
    }
}