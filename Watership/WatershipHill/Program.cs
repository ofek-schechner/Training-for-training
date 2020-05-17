using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WatershipHill
{
    class Program
    {
        static void Main(string[] args)
        {
            Hill hill = new Hill();

            HillManager.automateHill(hill);
        }
    }
}
