using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    class Tomcat : Cat
    {
        public Tomcat(int age, string name)
            : base(age, name, Sex.male)
        { }

        public Sex GetGender
        {
            get { return this.sex; }
            private set { } 
        }
    }
}
