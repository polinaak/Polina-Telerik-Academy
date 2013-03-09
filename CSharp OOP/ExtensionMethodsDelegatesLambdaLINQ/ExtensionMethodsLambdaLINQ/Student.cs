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
        private int Age { get; set; }
        //Constructor
        public Student(string firstName, string lastName, int Age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = Age;
        }
        //Methods with LINQ query operators
        public static void FindStudentByName(Student[] studentArr)
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

        public static void FindStudentByAge(Student[] studentArr)
        {
            var find =
                from student in studentArr
                where student.Age > 17 && student.Age < 25
                select student;

            int count = 0;
            foreach (var student in find)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine("There aren`t student between 18 and 24.");
            }
        }

        public static void DescendingSortLambda(Student[] studentArr)
        {
            var sorted =
                studentArr.OrderByDescending(x => x.FirstName).ThenByDescending(y => y.LastName);
            foreach (var student in sorted)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }

        public static void DescendingSortLINQ(Student[] studentArr)
        {
            var sorted =
                from student in studentArr
                orderby student.FirstName descending, student.LastName descending
                select student;
            foreach (var student in sorted)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
