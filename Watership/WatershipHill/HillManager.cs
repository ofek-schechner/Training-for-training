using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WatershipHill
{
    public static class HillManager
    {
        private static bool _toggle;

        public static void automateHill(Hill hill)
        {
            const int waitTimeInMilisec = 3000;

            HillManager._toggle = true;
            Thread.Sleep(waitTimeInMilisec);

            while (true)
            {
                while (HillManager._toggle)
                {
                    while (!Console.KeyAvailable)
                    {
                        hill.cycle();
                        Thread.Sleep(waitTimeInMilisec);
                    }
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        HillManager.toggleAutomation();
                    }
                }
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    HillManager.toggleAutomation();
                }
            }
        }

        public static void toggleAutomation()
        {
            HillManager._toggle = !HillManager._toggle;
        }
    }
}
