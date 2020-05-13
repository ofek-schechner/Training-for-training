using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    public static class RabbitManager
    {
        static private List<string> _maleNames = new List<string>() { "Bob", "Dan", "Greg" };
        static private List<string> _femaleNames = new List<string>() { "Dana", "Anna", "Noa" };

        // Generates a male rabbit's name
        public static string generateMaleName()
        {
            Random random = new Random();

            return RabbitManager._maleNames[random.Next(RabbitManager._maleNames.Count)];
        }

        // Generates a female rabbit's name
        public static string generateFemaleName()
        {
            Random random = new Random();

            return RabbitManager._femaleNames[random.Next(RabbitManager._femaleNames.Count)];
        }

        // Prints that a new rabbit was born
        public static void declareBirth(Rabbit rabbit)
        {
            Console.WriteLine(rabbit.sex() + " " + rabbit.color() + " Bunny " + rabbit.name() + " Was Born!");
        }
    }
}
