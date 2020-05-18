using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    public class Rabbit
    {
        private const int _startingAge = 0;

        private int _age;
        private Sex _sex;
        private Color _color;
        private string _name;
 
        public Rabbit()
        {
            this._age = Rabbit._startingAge;
            this._sex = this.generateSex();
            this._color = this.generateColor();
            this._name = this.generateName(this._sex);
        }

        public Rabbit(Sex sex)
        {
            this._age = Rabbit._startingAge; ;
            this._sex = sex;
            this._color = this.generateColor();
            this._name = this.generateName(this._sex);
        }

        public Rabbit(Color color)
        {
            this._age = Rabbit._startingAge; ;
            this._sex = this.generateSex();
            this._color = color;
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

        // Adds a year to the rabbit's age
        public void incrementAge()
        {
            this._age++;
        }

        // Checks whether the rabbit is old
        public bool isOld()
        {
            const int oldAge = 10;

            return this._age > oldAge;
        }

        // Checks whether the rabbit is a male
        public bool isMale()
        {
            return this._sex == Sex.Male;
        }

        // Checks whether the rabbit is a female
        public bool isFemale()
        {
            return this._sex == Sex.Female;
        }

        // Checks whether the rabbit is mature
        public bool isMature()
        {
            const int maturityAge = 2;

            return this._age >= maturityAge;
        }
    }
}
