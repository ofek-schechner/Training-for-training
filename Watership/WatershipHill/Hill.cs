using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    public class Hill
    {
        #region VALUES
        #region DATA_MEMBERS
        private List<Rabbit> _rabbits;
        private List<Rabbit> _deadRabbits;
        private List<Rabbit> _bornRabbits;
        private List<Rabbit> _mutantRabbits;
        private List<Rabbit> _regularRabbits;
        #endregion
        #endregion

        #region CONSTRUCTORS
        public Hill(int numOfMales, int numOfFemales)
        {
            this._rabbits = new List<Rabbit>();
            this._deadRabbits = new List<Rabbit>();
            this._bornRabbits = new List<Rabbit>();
            this._mutantRabbits = new List<Rabbit>();
            this._regularRabbits = new List<Rabbit>();

            for (int males = 0; males < numOfMales; males++)
            {
                Rabbit newRabbit = new Rabbit(Sex.Male);
                this._rabbits.Add(newRabbit);
                this._bornRabbits.Add(newRabbit);
            }

            for (int females = 0; females < numOfFemales; females++)
            {
                Rabbit newRabbit = new Rabbit(Sex.Female);
                this._rabbits.Add(newRabbit);
                this._bornRabbits.Add(newRabbit);
            }

            this.printStatistics();
        }

        public Hill()
        {
            this._rabbits = new List<Rabbit>();
            this._deadRabbits = new List<Rabbit>();
            this._bornRabbits = new List<Rabbit>();
            this._mutantRabbits = new List<Rabbit>();
            this._regularRabbits = new List<Rabbit>();
        }
        #endregion

        #region METHODS
        #region STATISTICS
        /// <summary>
        /// Declare the birth of all new rabbits
        /// </summary>
        private void declareBirths()
        {
            foreach (Rabbit rabbit in this._bornRabbits)
            {
                rabbit.declareBirth();
            }
        }

        /// <summary>
        /// Prints all the Hill's statistics.
        /// </summary>
        private void printStatistics()
        {
            this.sortByAge();
            this.printRabbitCount();
            this.declareDeaths();
            this.declareBirths();
            this.allRabbitsStats();
        }

        /// <summary>
        /// Counts all male, female and mutant rabbits, and prints the rabbit count.
        /// </summary>
        private void printRabbitCount()
        {
            int totalRabbits = this._rabbits.Count;
            int maleRabbits = 0;
            int femaleRabbits = 0;
            int mutantRabbits = 0;

            foreach (Rabbit rabbit in this._rabbits)
            {
                if (rabbit.isMale())
                {
                    maleRabbits++;
                }
                if (rabbit.isRadioactiveMutantVampireBunny())
                {
                    mutantRabbits++;
                }
            }

            femaleRabbits = totalRabbits - maleRabbits;

            Console.WriteLine("There are " + totalRabbits + " rabbits, " 
                              + maleRabbits + " of them are male, " 
                              + femaleRabbits + " of them are female, and " 
                              + mutantRabbits + " are radioactive mutant vampire rabbits.");
        }

        /// <summary>
        /// Declares the death of all dead rabbits
        /// </summary>
        private void declareDeaths()
        {
            foreach (Rabbit rabbit in this._deadRabbits)
            {
                rabbit.declareDeath();
            }
        }

        /// <summary>
        /// Prints all the rabbits' stats
        /// </summary>
        private void allRabbitsStats()
        {
            foreach (Rabbit rabbit in this._rabbits)
            {
                rabbit.printStatistics();
            }
        }

        /// <summary>
        /// Sorts the rabbit's list by age
        /// </summary>
        private void sortByAge()
        {
            this._rabbits.Sort((first, second) => first.age().CompareTo(second.age()));
        }
        #endregion

        #region CYCLE
        /// <summary>
        /// Commence a cycle
        /// </summary>
        public void cycle()
        {
            this.clearLists();
            this.incrementAges();
            this.killRabbits();
            this.procreate();
            this.mutateRabbits();
            this.printStatistics();
        }

        /// <summary>
        /// Add a year to all rabbit's age
        /// </summary>
        private void incrementAges()
        {
            foreach (Rabbit rabbit in this._rabbits)
            {
                rabbit.incrementAge();
            }
        }

        /// <summary>
        /// Kills all old rabbits
        /// </summary>
        private void killRabbits()
        {
            this.moveDeadRabbits();
            this.removeDeadRabbits();
        }

        /// <summary>
        /// Moves all dead rabbits to the dead rabbit's list
        /// </summary>
        private void moveDeadRabbits()
        {
            foreach (Rabbit rabbit in this._rabbits)
            {
                if (rabbit.isOld())
                {
                    this._deadRabbits.Add(rabbit);
                }
            }
        }

        /// <summary>
        /// Remove all dead rabbits from the living rabbit's list
        /// </summary>
        private void removeDeadRabbits()
        {
            this._rabbits.RemoveAll(rabbit => rabbit.isOld());
        }

        /// <summary>
        /// Clears the dead and newborn rabbits lists
        /// </summary>
        private void clearLists()
        {
            this._deadRabbits.Clear();
            this._bornRabbits.Clear();
            this._mutantRabbits.Clear();
            this._regularRabbits.Clear();
        }

        /// <summary>
        /// Matches all mature, non-mutant, male and female rabbits, and creates all children
        /// </summary>
        private void procreate()
        {
            foreach (Rabbit firstParent in this._rabbits)
            {
                if (firstParent.isMale() && firstParent.isMature() && !firstParent.isRadioactiveMutantVampireBunny())
                {
                    foreach (Rabbit secondParent in this._rabbits)
                    {
                        if (secondParent.isFemale() && secondParent.isMature() && !secondParent.isRadioactiveMutantVampireBunny())
                        {
                            Rabbit child = this.giveBirth(secondParent);
                            moveNewbornRabbit(child);
                        }
                    }
                }
            }

            this.moveRabbits();
        }

        /// <summary>
        /// Moves the child rabbit to the born and living list
        /// </summary>
        /// <param name="child"> A child rabbit </param>
        private void moveNewbornRabbit(Rabbit child)
        {
            this._bornRabbits.Add(child);
        }

        /// <summary>
        /// Creates a child based on it's mother
        /// </summary>
        /// <param name="mother"> A mother rabbit</param>
        /// <returns> A child rabbit </returns>
        private Rabbit giveBirth(Rabbit mother)
        {
            return new Rabbit(mother.color());
        }

        /// <summary>
        /// Move newborn rabbits to the living list
        /// </summary>
        private void moveRabbits()
        {
            foreach (Rabbit child in this._bornRabbits)
            {
                this._rabbits.Add(child);
            }
        }

        /// <summary>
        /// Makes all mutant rabbits bite regular rabbits
        /// </summary>
        private void mutateRabbits()
        {
            bool hasBitten;
            Rabbit bittenRabbit;

            this.separateMutants();

            foreach (Rabbit mutant in this._mutantRabbits)
            {
               hasBitten = false;

                while (!hasBitten)
                {
                    bittenRabbit = this.randomRabbit(this._regularRabbits);

                    if (!bittenRabbit.isRadioactiveMutantVampireBunny())
                    {
                        bittenRabbit.makeMutant();
                        hasBitten = true;
                    }
                }
            }
        }

        /// <summary>
        /// Gets a random rabbit from the given list
        /// </summary>
        /// <param name="rabbits"> A list of rabbits </param>
        /// <returns> A random rabbit </returns>
        private Rabbit randomRabbit(List<Rabbit> rabbits)
        {
            int numberOfRabbits = rabbits.Count();
            Random random = new Random();

            return rabbits[random.Next(numberOfRabbits)];
        }

        /// <summary>
        /// Separates the mutants from the regular rabbits
        /// </summary>
        private void separateMutants()
        {
            foreach(Rabbit rabbit in this._rabbits)
            {
                if (rabbit.isRadioactiveMutantVampireBunny())
                {
                    this._mutantRabbits.Add(rabbit);
                }
                else
                {
                    this._regularRabbits.Add(rabbit);
                }
            }
        }
        #endregion

        public List<Rabbit> rabbits()
        {
            return this._rabbits;
        }
        #endregion
    }
}
