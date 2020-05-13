using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    public class Rabbit
    {
        private int _age;
        private Sex _sex;
        private Color _color;
        private string _name;
 
        public Rabbit()
        {
            this._age = 0;
            this._sex = this.generateSex();
            this._color = this.generateColor();
            this._name = this.generateName(this._sex);
        }

        // Generates a name based on the given rabbit's sex
        private string generateName(Sex sex)
        {
            if (sex == Sex.Male)
            {
                return RabbitManager.generateMaleName();
            }
            else
            {
                return RabbitManager.generateFemaleName();
            }
        }

        // Generates the rabbit's sex
        private Sex generateSex()
        {
            Random random = new Random();
            Array sexes = Enum.GetValues(typeof(Sex));
            int numOfSexes = sexes.Length;

            return (Sex) sexes.GetValue(random.Next(numOfSexes));
        }

        // Generates the rabbit's color
        private Color generateColor()
        {
            Random random = new Random();
            Array colors = Enum.GetValues(typeof(Color));
            int numOfColors = colors.Length;

            return (Color) colors.GetValue(random.Next(numOfColors));
        }

        // Returns the rabbit's age
        public int age()
        {
            return this._age;
        }

        // Returns the rabbit's sex
        public Sex sex()
        {
            return this._sex;
        }

        // Returns the rabbit's color
        public Color color()
        {
            return this._color;
        }

        // Returns the rabbit's name
        public string name()
        {
            return this._name;
        }
    }
}
