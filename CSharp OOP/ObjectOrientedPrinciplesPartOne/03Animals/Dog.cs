using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    class Dog : Animal
    {
        //Constructors
        public Dog(int age, string name, Sex sex)
            : base(age, name, sex)
        { }

        public override void Sound()
        {
            Console.WriteLine("Dog says: Woof!"); 
        }
       
    }
}
