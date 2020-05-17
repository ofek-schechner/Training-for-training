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
            HillManager._toggle = true;

            while (true)
            {
                HillManager.runAutomation(hill);
                HillManager.checkAutomation();
            }
        }

        private static void toggleAutomation()
        {
            HillManager._toggle = !HillManager._toggle;
        }

        private static void checkAutomation()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                HillManager.toggleAutomation();
            }
        }

        private static bool isAutomationActivate()
        {
            return ((HillManager._toggle) && (!Console.KeyAvailable));
        }

        private static void runAutomation(Hill hill)
        {
            HillManager.runCycles(hill);
            HillManager.checkAutomation();
        }

        private static void runCycles(Hill hill)
        {
            const int waitTimeInMilisec = 3000;

            Thread.Sleep(waitTimeInMilisec);

            while (HillManager.isAutomationActivate())
            {
                hill.cycle();
                Thread.Sleep(waitTimeInMilisec);
            }
        }
    }
}
