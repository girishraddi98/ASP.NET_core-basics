using System;

public class Employee
{
    public string Firstname ="FN";
    public string Lastname="LN";
    
    public void PrintFullName()
    {
        Console.WriteLine($"{Firstname} {Lastname}");
    }

}
public class FullTimeEmployee : Employee
{
    public void PrintFullname()
    {
        Console.WriteLine($"FullTime: {Firstname} {Lastname}");
    }
}
//public new class FullTimeEmployee : Employee
//{
//    (base).PrintFullname();

//}

public class PartTimeEmployee : Employee
{
    public void PrintFullname()
    {
        Console.WriteLine($"PartTime: {Firstname} {Lastname}");
    }
}
public class TemproaryEmployee : Employee
{
    public void PrintFullname()
    {
        Console.WriteLine($"Temproary: {Firstname} {Lastname}");
    }
}
//public class TemproaryEmployee : Employee
//{
//    public override void PrintFullname()
//    {
//        Console.WriteLine($"Temproary: {Firstname} {Lastname}");
//    }
//}
public class Program
{
    public static void Main(string[] args)
    {
        FullTimeEmployee fte = new FullTimeEmployee();
        fte.PrintFullname();
        PartTimeEmployee pte = new PartTimeEmployee();
        pte.PrintFullname();
        TemproaryEmployee te = new TemproaryEmployee();
        te.PrintFullname();
        //TemproaryEmployee te = new TemproaryEmployee();
        //te.(Employee).PrintFullname();

    }
}