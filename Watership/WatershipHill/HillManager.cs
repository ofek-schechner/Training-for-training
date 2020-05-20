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
        /// <summary>
        /// Automates the given hill
        /// </summary>
        /// <param name="hill"> A hill </param>
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

        /// <summary>
        /// Toggles the state of the automation
        /// </summary>
        private static void toggleAutomation()
        {
            HillManager._toggle = !HillManager._toggle;
        }

        /// <summary>
        /// Checks whether the automation was toggled
        /// </summary>
        private static void checkToggle()
        {
            if (KeybaordIO.isEnterPressed())
            {
                HillManager.toggleAutomation();
            }
        }

        /// <summary>
        /// Checks whether the automation is active
        /// </summary>
        /// <returns> If the automation is active </returns>
        private static bool isAutomationActivate()
        {
             return ((HillManager._toggle) && (!KeybaordIO.isKeyPressed()));
        }

        /// <summary>
        /// Runs the given hill's automation
        /// </summary>
        /// <param name="hill"> A hill </param>
        private static void runAutomation(Hill hill)
        {
            while (HillManager.isAutomationActivate())
            {
                hill.cycle();
                Thread.Sleep(HillManager.WAIT_TIME_IN_MILISECONDS);
            }
        }
        #endregion

        /// <summary>
        /// Adds a rabbit to the given hill
        /// </summary>
        /// <param name="hill"> A hill </param>
        /// <param name="rabbit"> A rabbit </param>
        private static void addRabbit(Hill hill, Rabbit rabbit)
        {
            hill.rabbits().Add(rabbit);
        }
        #endregion
    }
}
