using System;
using ClassLibrary1; // Use the namespace, not the type
using ClassLibrary2; // Use the namespace, not the type
namespace Class{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Class Library 1 Names:");
            var class1 = new ClassLibrary1.Class1();
            class1.PrintNames();
            Console.WriteLine("\nClass Library 2 Names:");
            var class2 = new ClassLibrary2.Class1();
            class2.PrintNames();


        }
    }
}
