using System;

namespace Oop_model
{
    class Rectangle
    {
        internal double length;
        internal double width;
        internal int angle;

        public double GetArea()
        {
            return length * width;
        }
        public void GetDetails()
        {   
            Console.WriteLine("Length: " + length);
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Width: " + width);
            width = Convert.ToDouble(Console.ReadLine());
            
        }
        public void DisplayArea()

        {
            Console.WriteLine("length of rectangle: " + length);
            Console.WriteLine("width of rectangle: " + width);
            Console.WriteLine("Area of rectangle: " + GetArea());
        }

        public class ExecuteRectangle
        {
           public static void RectangleMain(string[] args)
            {
                Rectangle rect = new Rectangle();
                rect.GetDetails();
                rect.DisplayArea();
                Console.ReadLine();

            }



        }
    }
}
class Triangle
{
    public double height;

    public double TriangleArea(double length, double width, double height) {
        return length * width * height;

    }
    public void triangleDisplay()
    {
        
        Console.WriteLine("Area of triangle: " + GetArea());
    }
    public double GetArea()
    {
        Console.WriteLine("Height: " + height);
        height = Convert.ToDouble(Console.ReadLine());
        return 0.5 * height;
    }
    class ExecuteTriangle
    {
       public static void TriangleMain(string[] args)
        {
            Triangle tri = new Triangle();
            tri.GetArea();
            tri.triangleDisplay();
            Console.ReadLine();

        }
    }
    
static void Main(string[] args)
{
    Oop_model.Rectangle.ExecuteRectangle.RectangleMain(args);
    Triangle.ExecuteTriangle.TriangleMain(args);
}

}
