using System;


    public delegate void delegateProgram();
    class Message
    {
    public static void SampleMethodOne()
    {
        Console.WriteLine("hi");
    }
    public static void Main()
        {
            delegateProgram sam1, sam2, sam3, sam4;
            sam1= new delegateProgram(SampleMethodOne);
            sam2 = new delegateProgram(SampleMethodTwo);
            sam3 = new delegateProgram(SampleMethodThree);
            sam4=sam1+sam2+sam3;
            sam4();
        }
        
        public static void SampleMethodTwo()
        {
            Console.WriteLine("hi");
        }
        public static void SampleMethodThree()
        {
            Console.WriteLine("hi");
        }

    

}