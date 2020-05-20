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
        #region VALUES
        private const int WAIT_TIME_IN_MILISECONDS = 3000;

        #region DATA_MEMBERS
        private static bool _toggle;
        #endregion
        #endregion

        #region METHODS
        #region AUTOMATION
        // Automates the given hill
        public static void automateHill(Hill hill)
        {
            HillManager._toggle = true;

            Thread.Sleep(HillManager.WAIT_TIME_IN_MILISECONDS);

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
                Thread.Sleep(HillManager.WAIT_TIME_IN_MILISECONDS);
            }
        }
        #endregion

        // Adds a rabbit to the hill
        private static void addRabbit(Hill hill, Rabbit rabbit)
        {
            hill.rabbits().Add(rabbit);
        }
        #endregion
    }
}
