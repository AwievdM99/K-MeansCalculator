using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGL381_Calculator
{
    internal class Operations
    {

        public static void SelectedOption(string option)
        {
            switch (option)
            {
                case "1":
                    {
                        K_Means.StartKmeans();
                        break;
                    }
                case "2":
                    {
                        System.Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Display.InputError();
                        break;
                    }
            }
        }
    }
}
