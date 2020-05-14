using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatershipHill
{
    class Hill
    {
        private List<Rabbit> _rabbits;
        private List<Rabbit> _deadRabbits;
        private List<Rabbit> _bornRabbits;

        public Hill()
        {
            const int numOfFemales = 3;
            const int numOfMales = 2;

            this._rabbits = new List<Rabbit>();
            this._deadRabbits = new List<Rabbit>();
            this._bornRabbits = new List<Rabbit>();

            for (int males = 0; males < numOfMales; males++)
            {
                Rabbit newRabbit = RabbitManager.createMale();
                this._rabbits.Add(newRabbit);
                this._bornRabbits.Add(newRabbit);
            }

            for (int females = 0; females < numOfFemales; females++)
            {
                Rabbit newRabbit = RabbitManager.createFemale();
                this._rabbits.Add(newRabbit);
                this._bornRabbits.Add(newRabbit);
            }

            printStatistics();
        }

        // Declare birth on all new rabbit's
        private void declareBirths()
        {
            foreach (Rabbit rabbit in this._bornRabbits)
            {
                RabbitManager.declareBirth(rabbit);
            }
        }

        // Prints all the Hill's statistics.
        private void printStatistics()
        {
            this.printRabbitCount();
            this.declareBirths();
            this.declareDeaths();
        }

        // Counts all male and female rabbits, and prints the rabbit count.
        private void printRabbitCount()
        {
            int totalRabbits = this._rabbits.Count;
            int maleRabbits = 0;
            int femaleRabbits = 0;

            foreach (Rabbit rabbit in this._rabbits)
            {
                if (rabbit.sex() == Sex.Male)
                {
                    maleRabbits++;
                }
            }

            femaleRabbits = totalRabbits - maleRabbits;

            Console.WriteLine("There are " + totalRabbits + " rabbits, " + maleRabbits + " of them are male, and " + femaleRabbits + " of them are female.");
        }

        // Declares the death of all dead rabbits
        private void declareDeaths()
        {
            foreach (Rabbit rabbit in this._deadRabbits)
            {
                RabbitManager.declareDeath(rabbit);
            }
        }

        // Commence a cycle
        public void cycle()
        {
            this.clearLists();
            this.incrementAges();
            this.killRabbits();
        }

        // Add a year to all rabbit's age
        private void incrementAges()
        {
            foreach (Rabbit rabbit in this._rabbits)
            {
                rabbit.incrementAge();
            }
        }

        // Kills all old rabbits
        private void killRabbits()
        {
            this.moveDeadRabbits();
            this.removeDeadRabbits();
        }

        // Moves all dead rabbits to the dead rabbit's list
        private void moveDeadRabbits()
        {
            foreach (Rabbit rabbit in this._rabbits)
            {
                if (rabbit.age() > 10)
                {
                    this._deadRabbits.Add(rabbit);
                }
            }
        }

        // Remove all dead rabbits from the living rabbit's list
        private void removeDeadRabbits()
        {
            foreach (Rabbit rabbit in this._deadRabbits)
            {
                this._rabbits.Remove(rabbit);
            }
        }

        // Clears the dead and newborn rabbits lists
        private void clearLists()
        {
            this._deadRabbits.Clear();
            this._bornRabbits.Clear();
        }
    }
}
