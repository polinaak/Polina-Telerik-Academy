using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SchoolHierarchy
{
    class MyClass
    {
        //Fields
        private Teacher[] teachers;
        private Student[] students;
        private string textID;
        private string comment;

        //Constructors
        public MyClass(Teacher[] teachers, Student[] students, string textID)
            : this(teachers, students, textID, null)
        { }
        public MyClass(Teacher[] teachers, Student[] students, string textID, string comment)
        {
            this.teachers = teachers;
            this.students = students;
            this.textID = textID;
            this.comment = comment;
        }

        //Properties
        Teacher[] Teachers
        {
            get { return this.teachers; }
            set 
            {
                if (teachers.Length < 1)
                {
                    throw new ArgumentException("The number of teachers must be at least 1!");
                }

                this.teachers = value;
            }
        }
        Student[] Students
        {
            get { return this.students; }
            set
            {
                if (students.Length < 3)
                {
                    throw new ArgumentException("The number of students must be at least 3!");
                }

                this.students = value;
            }
        }

        string TextID
        {
            get { return this.textID; }
            set
            {
                if (textID.Length < 2)
                {
                    throw new ArgumentException("The number of symbols in the unique text identifier must be at least 2!");
                }

                this.textID = value;
            }
        }
    }
}
