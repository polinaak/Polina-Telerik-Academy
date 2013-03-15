using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SchoolHierarchy
{
    public class Person
    {
        //Fields
        private string name;
        private string comment;

        //Constructors
        public Person(string name)
            :this(name, null)
        {
           
        }
        public Person(string name, string comment)
            {
                this.name = name;
                this.comment = comment;
            }

        //Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                foreach (var letter in this.name)
                {
                    if (!(char.IsLetter(letter) || letter == ' '))
                    {
                        throw new ArgumentException("Wrong name!");
                    }
                }
                if (name.Length < 2)
                {
                    throw new ArgumentException("The name can`t be less 2 letters!");
                }
                this.name = value;
            }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
    }
}
