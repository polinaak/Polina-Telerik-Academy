using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void ResultConstructorCorrectTest1()
        {
            Result result = new Result(0, 0);
            Assert.AreEqual(0, result.Bulls);
            Assert.AreEqual(0, result.Cows);
        }

        [TestMethod]
        public void ResultConstructorCorrectTest2()
        {
            Result result = new Result(4, 0);
            Assert.AreEqual(4, result.Bulls);
            Assert.AreEqual(0, result.Cows);
        }

        [TestMethod]
        public void ResultConstructorCorrectTest3()
        {
            Result result = new Result(0, 4);
            Assert.AreEqual(0, result.Bulls);
            Assert.AreEqual(4, result.Cows);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ResultConstructorTooManyBullsTest()
        {
            Result result = new Result(5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ResultConstructorTooManyCowsTest()
        {
            Result result = new Result(0, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ResultConstructorTooManyTotalTest()
        {
            Result result = new Result(3, 3);
        }

        [TestMethod]
        public void ResultToStringTest()
        {
            Result result = new Result(2, 2);
            Assert.AreEqual("Bulls: 2, Cows: 2", result.ToString());
        }
    }
}
