using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Course
    {
        public const int MAX_STUDENTS = 29;
        private List<Student> studentsInCourse = new List<Student>();

        public Course()
        { }

        public List<Student> StudentsInCourse
        {
            get
            {
                return this.studentsInCourse;
            }
        }

        public string JoinCourse(Student nameOfStudent)
        {
            if (this.studentsInCourse.Count == MAX_STUDENTS)
            {
                throw new ArgumentException("There aren`t free places for this course!");
            }
            else
            {
                this.studentsInCourse.Add(nameOfStudent);
                return "Done!";
            }
        }

        public string RemoveCourse(Student nameOfStudent)
        {
            if (this.studentsInCourse.Contains(nameOfStudent) == true)
            {
                this.studentsInCourse.Remove(nameOfStudent);
                return "Done!";
            }
            else
            {
                throw new ArgumentException("Student is not added to this course!");
            }
        }
    }
}
