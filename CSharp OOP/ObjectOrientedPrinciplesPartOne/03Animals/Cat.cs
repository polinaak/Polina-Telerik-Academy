using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    class Cat : Animal
    {
        public Cat(int age, string name, Sex sex)
            : base(age, name, sex)
        { }

        public override void Sound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
