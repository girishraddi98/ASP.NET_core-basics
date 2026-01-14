using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ClassLibrary1
{
    public class Class1
    {
        private string[] names = new string[] { "Qwe", "Rty", "Iop" };

        public void PrintNames()
        {
            for (int i = 0; i < names.Length; i++)
            {

                Console.WriteLine($"{i + 1}.{names[i]}, ");
            }
            
        }
    }
}
