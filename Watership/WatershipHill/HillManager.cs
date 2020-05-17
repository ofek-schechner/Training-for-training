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
        private const int waitTimeInMilisec = 3000;
        private static bool _toggle;

        // Automates the given hill
        public static void automateHill(Hill hill)
        {
            HillManager._toggle = true;

            Thread.Sleep(HillManager.waitTimeInMilisec);

            while (true)
            { 
                HillManager.runAutomation(hill);
                HillManager.checkToggle();
            }
        }

        // Toggles the state of the automation
        private static void toggleAutomation()
        {
            HillManager._toggle = !HillManager._toggle;
        }

        // Checks whether the automation was toggled
        private static void checkToggle()
        {
            if (KeybaordIO.isEnterPressed())
            {
                HillManager.toggleAutomation();
            }
        }

        // Checks whether the automation is active
        private static bool isAutomationActivate()
        {
             return ((HillManager._toggle) && (!KeybaordIO.isKeyPressed()));
        }

        // Runs the given hill's automation
        private static void runAutomation(Hill hill)
        {
            while (HillManager.isAutomationActivate())
            {
                hill.cycle();
                Thread.Sleep(HillManager.waitTimeInMilisec);
            }
        }
    }
}
