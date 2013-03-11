using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SchoolHierarchy
{
    class School
    {
        //Fields
        private Student[] classStudents;

        //Constructor
        public School(Student[] classStudents)
        {
            this.classStudents = classStudents;
        }

        //Properties
        Student[] ClassStudents
        {
            get { return this.classStudents; }
            set
            {
                if (classStudents.Length < 1)
                {
                    throw new ArgumentException("The school must have at least one class!");
                }

                this.classStudents = value;
            }
        }
    }
}
