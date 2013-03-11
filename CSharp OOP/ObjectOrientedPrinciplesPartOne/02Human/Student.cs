using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Human
{
    class Student : Human
    {
        //Fields
        private int grade;

        //Constructor
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        //Properties
        public int Grade
        {
            get { return this.grade; }
            set
            {
                if (grade > 6 && grade < 2)
                {
                    throw new ArgumentException("The grade must be between 2 and 6!");
                }

                this.grade = value;
            }
        }

        public static void SortByGradeAscending(List<Student> students)
        {
            var sortedStudents =
                from student in students
                orderby student.grade, student.firstName
                select student;
            Console.WriteLine("The students are sorted by grade in ascending order:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student.firstName + " " + student.lastName + " " + student.grade);
            }
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }
    }
}
