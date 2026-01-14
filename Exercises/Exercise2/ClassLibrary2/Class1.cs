using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ClassLibrary2
{
    public class Class1
    {
        private string[] names = new string[] { "Abc", "bgd", "Ahd"};
        public void PrintNames()
        {
            for(int i = 0; i < names.Length; i++)
            {

                Console.WriteLine($"{i + 1}.{names[i]}, ");
            }
        }
    }
}
