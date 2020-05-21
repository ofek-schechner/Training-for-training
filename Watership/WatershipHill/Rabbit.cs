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

        #region PROPERTIES
        public int Age
        {
            get { return this._age; }
            private set { this._age = value; }
        }

        public Sex Sex
        {
            get { return this._sex; }
            private set { this._sex = value; }
        }

        public Color Color
        {
            get { return this._color; }
            private set { this._color = value; }
        }

        public string Name
        {
            get { return this._name; }
            private set { this._name = value; }
        }

        public bool IsRadioactiveMutantVampireBunny
        {
            get { return this._isRadioactiveMutantVampireBunny; }
            private set { this._isRadioactiveMutantVampireBunny = value; }
        }
        #endregion
        #endregion

        #region CONSTRUCTORS
        public Rabbit()
        {
            this.Age = Rabbit.STARTING_AGE;
            this.Sex = this.generateSex();
            this.Color = this.generateColor();
            this.Name = this.generateName(this.Sex);
            this.mutateRabbit();
        }

        public Rabbit(Sex sex)
        {
            this.Age = Rabbit.STARTING_AGE; ;
            this.Sex = sex;
            this.Color = this.generateColor();
            this.Name = this.generateName(this.Sex);
            this.mutateRabbit();
        }

        public Rabbit(Color color)
        {
            this.Age = Rabbit.STARTING_AGE; ;
            this.Sex = this.generateSex();
            this.Color = color;
            this.Name = this.generateName(this.Sex);
            this.mutateRabbit();
        }

        public Rabbit(int age, Sex sex, Color color, string name)
        {
            this.Age = age;
            this.Sex = sex;
            this.Color = color;
            this.Name = name;
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
            Console.WriteLine(this.Sex + " " + this.Color + " Bunny " + this.Name + " Was Born!");
        }

        /// <summary>
        /// Prints that the rabbit died
        /// </summary>
        public void declareDeath()
        {
            Console.WriteLine("Rabbit " + this.Name + " died");
        }

        /// <summary>
        /// Adds a year to the rabbit's age
        /// </summary>
        public void incrementAge()
        {
            this.Age++;
        }

        /// <summary>
        /// Checks whether the rabbit is old
        /// </summary>
        /// <returns> Is the rabbit old </returns>
        public bool isOld()
        {
            const int OLD_MUTATION_AGE = 50;
            const int OLD_AGE = 10;

            if (this.IsRadioactiveMutantVampireBunny)
            {
                return this.Age > OLD_MUTATION_AGE;
            }
            else
            {
                return this.Age > OLD_AGE;
            }
        }

        /// <summary>
        /// Checks whether the rabbit is a male
        /// </summary>
        /// <returns> Is the rabbit male </returns>
        public bool isMale()
        {
            return this.Sex == Sex.Male;
        }

        /// <summary>
        /// Checks whether the rabbit is a female
        /// </summary>
        /// <returns> Is the rabbit female </returns>
        public bool isFemale()
        {
            return this.Sex == Sex.Female;
        }

        /// <summary>
        /// Checks whether the rabbit is mature
        /// </summary>
        /// <returns> Is the rabbit mature </returns>
        public bool isMature()
        {
            const int MATURITY_AGE = 2;

            return this.Age >= MATURITY_AGE;
        }

        /// <summary>
        /// Makes the rabbit a mutant randomly
        /// </summary>
        private void mutateRabbit()
        {
            const double CHANCE_OF_BECOMING_MUTANT = 2.0;
            Random random = new Random();

            if (random.Next(0,100) <= CHANCE_OF_BECOMING_MUTANT)
            {
                this.IsRadioactiveMutantVampireBunny = true;
                Console.WriteLine("A mutant rabbit was born!");
            }
            else
            {
                this.IsRadioactiveMutantVampireBunny = false;
            }
        }

        /// <summary>
        /// Makes the rabbit a mutant
        /// </summary>
        public void makeMutant()
        {
            this.IsRadioactiveMutantVampireBunny = true;
        }

        /// <summary>
        /// Prints the rabbit's stats
        /// </summary>
        public void printStatistics()
        {
            string baseStatistc = "Name: " + this.Name + ", Age: " + this.Age + ", Color: " + this.Color + ", Sex: " + this.Sex + ", ";
            string isMutantStat;

            if (this.IsRadioactiveMutantVampireBunny)
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
    }
}
