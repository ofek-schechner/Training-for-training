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

        // Automates the given hill
        public static void automateHill(Hill hill)
        {
            HillManager._toggle = true;

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

        // Runs the automation
        private static void runAutomation(Hill hill)
        {
            HillManager.runCycles(hill);
            HillManager.checkToggle();
        }

        // Runs the given hill's cycle every 3 seconds
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
