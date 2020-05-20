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
        // Checks if a key is pressed
        public static bool isKeyPressed()
        {
            return Console.KeyAvailable;
        }

        // Checks whether enter was pressed
        public static bool isEnterPressed()
        {
            return (Console.ReadKey(true).Key == ConsoleKey.Enter);
        }
        #endregion
    }
}
