using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SchoolHierarchy
{
    public class Student : Person
    {
        //Field
        private int classNumber;

        //Constructor
        public Student(string name, int classNumber)
            : this(name, classNumber, null)
        { }

        public Student(string name, int classNumber, string comment)
            : base(name, comment)
        {
            this.classNumber = classNumber;
        }

        //Property
        public int ClassNumber
        {
            get { return this.classNumber; }
            set { this.classNumber = value; }
        }
    }
}
