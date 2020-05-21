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
        private bool _isRadioactiveMutantVampireBunny;
        #endregion
        #endregion

        #region CONSTRUCTORS
        public Rabbit()
        {
            this._age = Rabbit.STARTING_AGE;
            this._sex = this.generateSex();
            this._color = this.generateColor();
            this._name = this.generateName(this._sex);
            this.mutateRabbit();
        }

        public Rabbit(Sex sex)
        {
            this._age = Rabbit.STARTING_AGE; ;
            this._sex = sex;
            this._color = this.generateColor();
            this._name = this.generateName(this._sex);
            this.mutateRabbit();
        }

        public Rabbit(Color color)
        {
            this._age = Rabbit.STARTING_AGE; ;
            this._sex = this.generateSex();
            this._color = color;
            this._name = this.generateName(this._sex);
            this.mutateRabbit();
        }

        public Rabbit(int age, Sex sex, Color color, string name)
        {
            this._age = age;
            this._sex = sex;
            this._color = color;
            this._name = name;
            this.mutateRabbit();
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Generates a name based on the sex
        /// </summary>
        /// <param name="sex"> The rabbit's sex </param>
        /// <returns> The name </returns>
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

        /// <summary>
        /// Generates the rabbit's sex
        /// </summary>
        /// <returns> The rabbit's sex </returns>
        private Sex generateSex()
        {
            const int NUM_OF_SEXES = 2;
            Random random = new Random();
            Array sexes = Enum.GetValues(typeof(Sex));

            return (Sex) sexes.GetValue(random.Next(NUM_OF_SEXES));
        }

        /// <summary>
        /// Generates the rabbit's color
        /// </summary>
        /// <returns> The rabbit's color </returns>
        private Color generateColor()
        {
            Random random = new Random();
            Array colors = Enum.GetValues(typeof(Color));
            int numOfColors = colors.Length;

            return (Color) colors.GetValue(random.Next(numOfColors));
        }

        /// <summary>
        /// Generates a male rabbit's name
        /// </summary>
        /// <returns> The rabbit's name </returns>
        public string generateMaleName()
        {
            Random random = new Random();

            return Rabbit._maleNames[random.Next(Rabbit._maleNames.Count)];
        }

        /// <summary>
        /// Generates a female rabbit's name
        /// </summary>
        /// <returns> The rabbit's name </returns>
        public string generateFemaleName()
        {
            Random random = new Random();

            return Rabbit._femaleNames[random.Next(Rabbit._femaleNames.Count)];
        }

        /// <summary>
        /// Prints that the rabbit was born
        /// </summary>
        public void declareBirth()
        {
            Console.WriteLine(this.sex() + " " + this.color() + " Bunny " + this.name() + " Was Born!");
        }

        /// <summary>
        /// Prints that the rabbit died
        /// </summary>
        public void declareDeath()
        {
            Console.WriteLine("Rabbit " + this.name() + " died");
        }

        /// <summary>
        /// Adds a year to the rabbit's age
        /// </summary>
        public void incrementAge()
        {
            this._age++;
        }

        /// <summary>
        /// Checks whether the rabbit is old
        /// </summary>
        /// <returns> Is the rabbit old </returns>
        public bool isOld()
        {
            const int OLD_MUTATION_AGE = 50;
            const int OLD_AGE = 10;

            if (this._isRadioactiveMutantVampireBunny)
            {
                return this._age > OLD_MUTATION_AGE;
            }
            else
            {
                return this._age > OLD_AGE;
            }
        }

        /// <summary>
        /// Checks whether the rabbit is a male
        /// </summary>
        /// <returns> Is the rabbit male </returns>
        public bool isMale()
        {
            return this._sex == Sex.Male;
        }

        /// <summary>
        /// Checks whether the rabbit is a female
        /// </summary>
        /// <returns> Is the rabbit female </returns>
        public bool isFemale()
        {
            return this._sex == Sex.Female;
        }

        /// <summary>
        /// Checks whether the rabbit is mature
        /// </summary>
        /// <returns> Is the rabbit mature </returns>
        public bool isMature()
        {
            const int MATURITY_AGE = 2;

            return this._age >= MATURITY_AGE;
        }


        private void mutateRabbit()
        {
            const double CHANCE_OF_BECOMING_MUTANT = 2.0;
            Random random = new Random();

            if (random.Next(0,100) <= CHANCE_OF_BECOMING_MUTANT)
            {
                this._isRadioactiveMutantVampireBunny = true;
            }
            else
            {
                this._isRadioactiveMutantVampireBunny = false;
            }
        }

        public void makeMutant()
        {
            this._isRadioactiveMutantVampireBunny = true;
        }

        public void printStatistics()
        {
            string baseStatistc = "Name: " + this._name + ", Age: " + this._age + ", Color: " + this._color + ", Sex: " + this._sex + ", ";
            string isMutantStat;

            if (this._isRadioactiveMutantVampireBunny)
            {
                isMutantStat = "Is a mutant.";
            }
            else
            {
                isMutantStat = "Is not a mutant.";
            }

            Console.WriteLine(baseStatistc + isMutantStat);
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

        // Returns whether the rabbit is a mutant
        public bool isRadioactiveMutantVampireBunny()
        {
            return this._isRadioactiveMutantVampireBunny;
        }
    }
}
