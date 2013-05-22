using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCreateStudentsInCourseSuccessfully()
        {
            Course newCourse = new Course();
        }

        [TestMethod]
        public void TestJoinCourseSuccessfully()
        {
            Course course = new Course();
            Student student = new Student("Valia", 34567);
            string result = course.JoinCourse(student);
            Assert.AreEqual("Done!", result);
        }

        [TestMethod]
        public void TestJoinCourse15StudentsSuccessfully()
        {
            Course course = new Course();
            int joinStudents = 14;

            for (int i = 0; i < joinStudents; i++)
            {
                course.JoinCourse(new Student("student" + i, 30002 + i));
            }
        }

        [TestMethod]
        public void TestJoinCourseMaximumStudentsSuccessfully()
        {
            Course course = new Course();
            int maxStudents = 29;

            for (int i = 0; i < maxStudents; i++)
            {
                course.JoinCourse(new Student("student"+i, 10002+i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestJoinCourse31Students()
        {
            Course course = new Course();
            int maxStudents = 30;

            for (int i = 0; i < maxStudents; i++)
            {
                course.JoinCourse(new Student("student" + i, 20002 + i));
            }
        }

        [TestMethod]
        public void TestRemoveCourseSuccessfully()
        {
            Course course = new Course();
            Student student = new Student("Gosho", 34000);
            course.JoinCourse(student);
            string result = course.RemoveCourse(student);
            Assert.AreEqual("Done!", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveCourseStudentNotAddedToCourse()
        {
            Student student = new Student("Pesho", 23412);
            Course course = new Course();
            course.RemoveCourse(student);
        }

        [TestMethod]
        public void TestListSuccessfull()
        {
            Course course = new Course();
            int joinStudents = 14;

            for (int i = 0; i < joinStudents; i++)
            {
                course.JoinCourse(new Student("student" + i, 38002 + i));
            }
            List<Student> students = new List<Student>(course.StudentsInCourse);
        }
    }
}
