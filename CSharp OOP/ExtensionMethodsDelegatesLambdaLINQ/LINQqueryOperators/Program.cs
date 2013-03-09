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
            studentArr[0] = new Student("Pesho", "Georgiev");
            studentArr[1] = new Student("Ilian", "Ivanov");
            studentArr[2] = new Student("Georgi", "Siromahov");
           
            //Test
            Student.FindStudent(studentArr);
        }
    }
}
