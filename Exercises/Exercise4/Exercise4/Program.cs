namespace Exercise4
{
    using System;

    interface IWORK1
    {
        public void Print();
    }
    //interface IWORK2
    //{
    //    public void Print();
    //}
    interface IWORK2 : IWORK1
    {
        public void Print();
    }
    public class Work : Job, IWORK1, IWORK2
    {
        public void Print()
        {
            Console.WriteLine("Work1 class Print method called.");
        }
        void IWORK2.Print()
        {
            Console.WriteLine("Work2 class Print method called.");
        }

        public static void Main(string[] args)
        {
            Work work = new Work();
            ((IWORK2)work).Print();
            ((IWORK1)work).Print();
            // Calls IWORK2's Print method
            // no need to cast to implement the method from the abstract class Job
        }
    }
    public abstract class Job
    {
        public void Print()
        {
            Console.WriteLine("Job class Print method called.");
        }
    }

    public abstract class Task
    {
        public abstract void Display() //??
        //An abstarct class can't have a method with body
        {
            Console.WriteLine("Task class Display method called.");
        }
        int data = 10; //??
        //An abstract class can't have fields


    }

    public interface ITask
    {
        int num; //??
        //An interface can't have fields
        void Show() //??
        //An interface can't have a method with body
        //it is public by default cannot have other access modifier
        {
            Console.WriteLine("Task interface Show method called.");
        }
        
    }
    public class Assignment : Task, ITask //?? can't inherit from abstract class Task 
    {
        public void /*override*/ Display()//?? can't inherit from abstract class Task OR implement override Task
        {
            Console.WriteLine("Assignment class Display method called.");
        }
        public void Show()
        {
            Console.WriteLine("Assignment class Show method called.");
        }
    }
}