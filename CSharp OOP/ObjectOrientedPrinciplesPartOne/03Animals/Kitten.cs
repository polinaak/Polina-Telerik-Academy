using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    class Kitten : Cat
    {
        public Kitten(int age, string name)
            : base(age, name, Sex.female)
        { }

        public Sex GetGender
        {
            get { return this.sex; }
            private set { }
        }
    }
}
