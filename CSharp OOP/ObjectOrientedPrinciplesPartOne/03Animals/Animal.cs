using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    public abstract class Animal : ISound
    {
        public enum Sex { male, female}
        //Fields
        protected int age;
        protected string name;
        protected Sex sex;

        //Constructor
        public Animal(int age, string name, Sex sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }

        //Properties
        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age < 0 && this.age > 50)
                {
                    throw new ArgumentException("The age must be between 0 and 50!");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                foreach (var letter in this.name)
	            {
                    if (!(char.IsLetter(letter)))
                    {
                        throw new ArgumentException("The name have to contains only letters!");
                    }
	            }
              this.name = value;
            }
        }

        public Sex GetSex
        {
            get { return this.sex; }
        }

        //Interface method
        public virtual void Sound()
        {
            throw new ArgumentException("Not implemented!");
        }

        public static double AverageAge(Animal[] animals)
        {
            var average =
                from animal in animals
                select animal.age;
            double averageAge = average.Average();
            return averageAge;
        }
    }
}
 