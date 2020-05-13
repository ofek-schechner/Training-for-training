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

        private int age;
        private Sex sex;
        private Color color;
        private string name;
 
        public Rabbit()
        {
            this.age = 0;
        }

        public Rabbit(int age, Sex sex, Color color, string name)
        {
            this.age = age;
            this.sex = sex;
            this.color = color;
            this.name = name;
        }
        static private string getName(Sex sex)
        {
            Random random = new Random();

            if (sex == Sex.Male)
            {
                return Rabbit.maleNames[random.Next(Rabbit.maleNames.Count)];
            }
            else
            {
                return Rabbit.femaleNames[random.Next(Rabbit.femaleNames.Count)];
            }
        }


    }
}
