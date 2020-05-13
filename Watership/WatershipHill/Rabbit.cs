using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    public class Rabbit
    {
        static private List<string> maleNames = new List<string>() { "Bob", "Dan", "Greg"};
        static private List<string> femaleNames = new List<string>() { "Dana", "Anna", "Noa"};

        private int _age;
        private Sex _sex;
        private Color _color;
        private string _name;
 
        public Rabbit()
        {
            this._age = 0;
            this._sex = this.generateSex();
            this._color = this.generateColor();
            this._name = Rabbit.generateName(this._sex);
        }

        static private string generateName(Sex sex)
        {
            if (sex == Sex.Male)
            {
                return generateMaleName();
            }
            else
            {
                return generateFemaleName();
            }
        }

        static private string generateMaleName()
        {
            Random random = new Random();

            return Rabbit.maleNames[random.Next(Rabbit.maleNames.Count)];
        }

        static private string generateFemaleName()
        {
            Random random = new Random();

            return Rabbit.femaleNames[random.Next(Rabbit.femaleNames.Count)];
        }

        private Sex generateSex()
        {
            Random random = new Random();
            Array sexes = Enum.GetValues(typeof(Sex));
            int numOfSexes = sexes.Length;

            return (Sex) sexes.GetValue(random.Next(numOfSexes));
        }

        private Color generateColor()
        {
            Random random = new Random();
            Array colors = Enum.GetValues(typeof(Color));
            int numOfColors = colors.Length;

            return (Color)colors.GetValue(random.Next(numOfColors));
        }

        public void declareBirth()
        {
            Console.WriteLine(this._sex + " " + this._color + " Bunny " + this._name + " Was Born!");
        }
    }
}
