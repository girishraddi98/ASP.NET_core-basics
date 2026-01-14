using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using static ClassLibrary1.Class1;

public static class Program
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