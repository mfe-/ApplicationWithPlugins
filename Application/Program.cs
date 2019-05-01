using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            MathCore _MathCore = new MathCore(Environment.CurrentDirectory);

            System.Console.WriteLine(_MathCore.Calc("sqrt(3)"));

            System.Console.WriteLine(_MathCore.Calc("cos(5)"));

            System.Console.WriteLine(_MathCore.Calc("mod(5)"));

            System.Console.WriteLine(_MathCore.Calc("sin(5)"));

            System.Console.ReadLine();

        }
    }
}
