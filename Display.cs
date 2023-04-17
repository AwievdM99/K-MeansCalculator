using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGL381_Calculator
{
    internal class Display
    {
        public static void InputError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INPUT NOT IN RANGE!");
            Console.WriteLine("PRESS ENTER TO TRY AGAIN!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Created by Awie van der Merwe");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteOptions()
        {
            List<string> options = new List<string>();
            List<int> complete = new List<int>();
            options.Add("K-Means");
            options.Add("Exit");
            complete.Add(1);
            complete.Add(2);
            Console.WriteLine("Select the operation you wish to complete. Please NOTE only green options are available");
            Console.WriteLine();
            for (int i = 0; i < options.Count; i++)
            {
                if (complete[i] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (complete[i] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (complete[i] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("\t" + (i + 1).ToString() + " - " + options[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Input option");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
