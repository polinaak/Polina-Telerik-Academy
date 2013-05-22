using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestCreateStudentSuccessfullyName()
        {
            Student newStudent = new Student("Vasil", 12345);
            string name = newStudent.Name;
            Assert.AreSame("Vasil", name);
        }

        [TestMethod]
        public void TestCreateStudentSuccessfullyNumber()
        {
            Student newStudent = new Student("Maria", 11112);
            int number = newStudent.UniqueNumber;
            Assert.AreEqual(11112, number);
        }

        [TestMethod]
        public void TestCreateStudentSuccessfullyNumberMinimalBound()
        {
            Student newStudent = new Student("Maria", 10000);
            int number = newStudent.UniqueNumber;
            Assert.AreEqual(10000, number);
        }

        [TestMethod]
        public void TestCreateStudentSuccessfullyNumberMaximalBound()
        {
            Student newStudent = new Student("Maria", 99999);
            int number = newStudent.UniqueNumber;
            Assert.AreEqual(99999, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentWithEmptyStringForName()
        {
            Student newStudent = new Student("", 12356);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentsWithSameUniqueNumber()
        {
            Student firstStudent = new Student("Lili", 22222);
            Student secondStudent = new Student("Petia", 22222);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateUniqueNumberSmallerThanRange()
        {
            Student newStudent = new Student("Katia", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateUniqueNumberGreaterThanRange()
        {
            Student newStudent = new Student("Katia", 100000);
        }
    }
}
