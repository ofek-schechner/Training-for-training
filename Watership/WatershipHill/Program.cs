using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    class Program
    {
        static void Main(string[] args)
        {
            Hill hill = new Hill();

            while (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                hill.cycle();
            }
        }
    }
}
