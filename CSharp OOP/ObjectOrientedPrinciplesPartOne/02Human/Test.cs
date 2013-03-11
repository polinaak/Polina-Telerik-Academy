using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Define abstract class Human with first name and last name. Define new class Student 
//which is derived from Human and has new field – grade. Define class Worker derived 
//from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
//that returns money earned by hour by the worker. Define the proper constructors and 
//properties for this hierarchy. Initialize a list of 10 students and sort them by grade 
//in ascending order (use LINQ or OrderBy() extension method). Initialize a list of 10 
//workers and sort them by money per hour in descending order. Merge the lists and sort 
//them by first name and last name.

namespace _02Human
{
    class Test
    {
        static void Main()
        {
            //Make list of students with grades
            List<Student> students = new List<Student>();
            Student st1 = new Student("Gosho", "Ivanov", 4);
            Student st2= new Student("Ilia", "Georgiev", 5);
            Student st3 = new Student("Pesho", "Stefanov", 3);
            Student st4 = new Student("Ivan", "Ivanchev", 6);
            Student st5 = new Student("Tisho", "Ivanov", 2);
            Student st6 = new Student("Petq", "Ivanova", 4);
            Student st7 = new Student("Hristina", "Ivancheva", 6);
            Student st8 = new Student("Hristo", "Ivanov", 3);
            Student st9 = new Student("Pencho", "Hristov", 4);
            Student st10 = new Student("Gosho", "Georgiev", 4);
            students.Add(st1);
            students.Add(st2);
            students.Add(st3);
            students.Add(st4);
            students.Add(st5);
            students.Add(st6);
            students.Add(st7);
            students.Add(st8);
            students.Add(st9);
            students.Add(st10);

            //Test method 
            Student.SortByGradeAscending(students);
            Console.WriteLine("--------------------------------------------");

            //Make list with workers
            List<Worker> workers = new List<Worker>();
            Worker w1 = new Worker("Ivancho", "Muftadjiev", 100, 4);
            Worker w2 = new Worker("Iliana", "Georgieva", 120, 5);
            Worker w3 = new Worker("Vladimir", "Petrov",200, 16);
            Worker w4 = new Worker("Vasil", "Vasilev", 150, 10);
            Worker w5 = new Worker("Aleksandyr", "Ivanov", 230, 15);
            Worker w6 = new Worker("Ani", "Tihomirova", 170, 13);
            Worker w7 = new Worker("Boqna", "Marinova", 120, 13);
            Worker w8 = new Worker("Hristo", "Hristov", 100, 5);
            Worker w9 = new Worker("Cvetelina", "Grahich", 120, 6);
            Worker w10 = new Worker("Georgi", "Petrov", 160, 7);
            workers.Add(w1);
            workers.Add(w2);
            workers.Add(w3);
            workers.Add(w4);
            workers.Add(w5);
            workers.Add(w6);
            workers.Add(w7);
            workers.Add(w8);
            workers.Add(w9);
            workers.Add(w10);
            
            //Test method
            Worker.SortByMoneyPerHourDescending(workers);
            Console.WriteLine("--------------------------------------------");
          
           //Merge lists
            List<dynamic> merged = new List<dynamic>(students.Concat<dynamic>(workers));

            //Sort merged list by LINQ
            var sortedMergedList =
                from person in merged
                orderby person.GetFirstName(), person.GetLastName()
                select person;
            Console.WriteLine("Merge list sorted by names with LINQ:");
            foreach (var person in sortedMergedList)
            {
                Console.WriteLine(person.GetFirstName() + " " + person.GetLastName());
            }
            Console.WriteLine("--------------------------------------------");

            //Sort merged list by Lambda expressions
            var sortedWithLamba = merged.OrderBy(x => x.GetFirstName()).ThenBy(y => y.GetLastName());
            Console.WriteLine("Merge list sorted by names with Lambda expressions:");
            foreach (var person in sortedWithLamba)
            {
                Console.WriteLine(person.GetFirstName() + " " + person.GetLastName());
            }
        }
    }
}
