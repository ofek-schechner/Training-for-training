using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    public static class KeybaordIO
    {
        #region METHODS
        /// <summary>
        /// Checks whether a key is pressed
        /// </summary>
        /// <returns> If a key was pressed </returns>
        public static bool isKeyPressed()
        {
            return Console.KeyAvailable;
        }

        /// <summary>
        /// Checks whether enter was pressed
        /// </summary>
        /// <returns> If a enter was pressed </returns>
        public static bool isEnterPressed()
        {
            return (Console.ReadKey(true).Key == ConsoleKey.Enter);
        }
        #endregion
    }
}
