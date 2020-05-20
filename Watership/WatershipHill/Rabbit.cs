using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    public class Rabbit
    {
        #region VALUES
        private const int STARTING_AGE = 0;

        #region STATIC_VALUES
        static private List<string> _maleNames = new List<string>() { "Bob", "Dan", "Greg" };
        static private List<string> _femaleNames = new List<string>() { "Dana", "Anna", "Noa" };
        #endregion

        #region DATA_MEMBERS
        private int _age;
        private Sex _sex;
        private Color _color;
        private string _name;

        #endregion
        #endregion

        #region CONSTRUCTORS
        public Rabbit()
        {
            this._age = Rabbit.STARTING_AGE;
            this._sex = this.generateSex();
            this._color = this.generateColor();
            this._name = this.generateName(this._sex);
        }

        public Rabbit(Sex sex)
        {
            this._age = Rabbit.STARTING_AGE; ;
            this._sex = sex;
            this._color = this.generateColor();
            this._name = this.generateName(this._sex);
        }

        public Rabbit(Color color)
        {
            this._age = Rabbit.STARTING_AGE; ;
            this._sex = this.generateSex();
            this._color = color;
            this._name = this.generateName(this._sex);
        }
        #endregion

        #region METHODS
        // Generates a name based on the given rabbit's sex
        private string generateName(Sex sex)
        {
            if (sex == Sex.Male)
            {
                return this.generateMaleName();
            }
            else
            {
                return this.generateFemaleName();
            }
        }

        // Generates the rabbit's sex
        private Sex generateSex()
        {
            const int NUM_OF_SEXES = 2;
            Random random = new Random();
            Array sexes = Enum.GetValues(typeof(Sex));

            return (Sex) sexes.GetValue(random.Next(NUM_OF_SEXES));
        }

        // Generates the rabbit's color
        private Color generateColor()
        {
            Random random = new Random();
            Array colors = Enum.GetValues(typeof(Color));
            int numOfColors = colors.Length;

            return (Color) colors.GetValue(random.Next(numOfColors));
        }

        // Generates a male rabbit's name
        public string generateMaleName()
        {
            Random random = new Random();

            return Rabbit._maleNames[random.Next(Rabbit._maleNames.Count)];
        }

        // Generates a female rabbit's name
        public string generateFemaleName()
        {
            Random random = new Random();

            return Rabbit._femaleNames[random.Next(Rabbit._femaleNames.Count)];
        }

        // Prints that the given rabbit was born
        public void declareBirth()
        {
            Console.WriteLine(this.sex() + " " + this.color() + " Bunny " + this.name() + " Was Born!");
        }

        // Prints that the given rabbit died
        public void declareDeath()
        {
            Console.WriteLine("Rabbit " + this.name() + " died");
        }

        // Adds a year to the rabbit's age
        public void incrementAge()
        {
            this._age++;
        }

        // Checks whether the rabbit is old
        public bool isOld()
        {
            const int OLD_AGE = 10;

            return this._age > OLD_AGE;
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
            const int MATURITY_AGE = 2;

            return this._age >= MATURITY_AGE;
        }

        #endregion
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
