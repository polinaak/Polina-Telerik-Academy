using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that from a given array of students finds all students whose 
//first name is before its last name alphabetically. Use LINQ query operators.

namespace _03FirstNameBeforeLastAlphabetically
{
    class Program
    {
        static void Main()
        {
            Student[] studentArr = new Student[3];
            studentArr[0] = new Student("Pesho", "Georgiev", 18);
            studentArr[1] = new Student("Ilian", "Ivanov", 24);
            studentArr[2] = new Student("Georgi", "Siromahov", 25);
           
            //Test methods
            Console.WriteLine("Students which first name is before its last name alphabetically:");
            Student.FindStudentByName(studentArr);
            Console.WriteLine();
            Console.WriteLine("Students between 18 and 24:");
            Student.FindStudentByAge(studentArr);
            Console.WriteLine();
            Console.WriteLine("Sorted students in descending order with Lambda expressions:");
            Student.DescendingSortLambda(studentArr);
            Console.WriteLine();
            Console.WriteLine("Sorted students in descending order with LINQ:");
            Student.DescendingSortLINQ(studentArr);
        }
    }
}
