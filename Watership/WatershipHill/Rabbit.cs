﻿using System;
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

        private int age;
        private Sex sex;
        private Color color;
        private string name;
 
        public Rabbit()
        {
            this.age = 0;
            this.sex = this.generateSex();
            this.color = this.generateColor();
            this.name = Rabbit.generateName(this.sex);
        }

        public Rabbit(int age, Sex sex, Color color, string name)
        {
            this.age = age;
            this.sex = sex;
            this.color = color;
            this.name = name;
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
            Console.WriteLine(this.sex + " " + this.color + " Bunny " + this.name + " Was Born!");
        }
    }
}