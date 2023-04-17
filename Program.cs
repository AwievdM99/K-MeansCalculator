using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGL381_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Display.WriteHeader();
                Display.WriteOptions();
                Operations.SelectedOption(Console.ReadLine());
                Console.ReadKey();
            }   
        }
    }
}
