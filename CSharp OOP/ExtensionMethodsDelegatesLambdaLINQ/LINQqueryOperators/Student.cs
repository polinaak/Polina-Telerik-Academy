using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FirstNameBeforeLastAlphabetically
{
    public class Student
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        //Constructor
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        //Method with LINQ query operators
        public static void FindStudent(Student[] studentArr)
        {
            var findedStudents =
                from student in studentArr
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            int count = 0;
            foreach (var student in findedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine("There aren`t any students that satisfy the conditions");
            }
        }
    }
}
