using ClassLibrary1;

namespace ClassLibrary1
{
    public class Class1
    {
        public virtual void Print()
        {
        Console.WriteLine("Hello World!");}
    }
}
    public class BaseClass: Class1
{
    public override void Print() { 
        Console.WriteLine("Hello from BaseClass!");
    }
}
//public class BaseClass: Class1
//{
//    public new void Print() { 
//        Console.WriteLine("Hello from BaseClass!");
//    }
//}
public static class Program
{
    public static void Main()
    {
        BaseClass obj = new BaseClass();
        obj.Print();
    }
}
