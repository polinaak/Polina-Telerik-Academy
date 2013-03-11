using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//We are given a school. In the school there are classes of students. Each class has a set of teachers.
//Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have 
//unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of
//exercises. Both teachers and students are people. Students, classes, teachers and disciplines could
//have optional comments (free text block).Your task is to identify the classes (in terms of  OOP) and
//their attributes and operations, encapsulate their fields, define the class hierarchy and create
//a class diagram with Visual Studio.

namespace _01SchoolHierarchy
{
    class Test
    {
        static void Main()
        {
            //Person
            Person person = new Person("Ivo");

            //Disciplines
            List<Discipline> subjects = new List<Discipline>();
            Discipline d = new Discipline("geografiq", 3, 3);
            Discipline d2 = new Discipline("matematika", 4, 2);
            subjects.Add(d);
            subjects.Add(d2);

            //Teachers
            Teacher t = new Teacher("Ivanov", subjects);
            Teacher[] teacher = new Teacher[1];
            teacher[0] = t;

            //Students and classes
            Student st = new Student("Ivan Ivanov", 23);
            Student st2 = new Student("Gosho Georgiev", 2, "This is comment");
            Student st3 = new Student("Pesho Petkov", 6);
            Student[] students = new Student[3];
            students[0] = st;
            students[1] = st2;
            students[2] = st3;
            MyClass firstClass = new MyClass(teacher, students, "10A");

            //School
            School testClass = new School(students);
        }
    }
}
