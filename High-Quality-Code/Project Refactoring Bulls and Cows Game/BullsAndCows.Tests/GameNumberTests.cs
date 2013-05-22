using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class GameNumberTests
    {
        [TestMethod]
        public void NumberParameterlessConstructorCorrectTest1()
        {
            GameNumber number = new GameNumber();
            Assert.IsTrue(0 <= number.FirstDigit && number.FirstDigit < 10);
            Assert.IsTrue(0 <= number.SecondDigit && number.SecondDigit < 10);
            Assert.IsTrue(0 <= number.ThirdDigit && number.ThirdDigit < 10);
            Assert.IsTrue(0 <= number.FourthDigit && number.FourthDigit < 10);
        }

        [TestMethod]
        public void NumberParameterlessConstructorCorrectTest2()
        {
            GameNumber number = new GameNumber();
            Assert.IsTrue(0 <= number.FirstDigit && number.FirstDigit < 10);
            Assert.IsTrue(0 <= number.SecondDigit && number.SecondDigit < 10);
            Assert.IsTrue(0 <= number.ThirdDigit && number.ThirdDigit < 10);
            Assert.IsTrue(0 <= number.FourthDigit && number.FourthDigit < 10);
        }

        [TestMethod]
        public void NumberParameterlessConstructorCorrectTest3()
        {
            GameNumber number = new GameNumber();
            Assert.IsTrue(0 <= number.FirstDigit && number.FirstDigit < 10);
            Assert.IsTrue(0 <= number.SecondDigit && number.SecondDigit < 10);
            Assert.IsTrue(0 <= number.ThirdDigit && number.ThirdDigit < 10);
            Assert.IsTrue(0 <= number.FourthDigit && number.FourthDigit < 10);
        }

        [TestMethod]
        public void NumberParameterlessConstructorCorrectTest4()
        {
            GameNumber number = new GameNumber();
            Assert.IsTrue(0 <= number.FirstDigit && number.FirstDigit < 10);
            Assert.IsTrue(0 <= number.SecondDigit && number.SecondDigit < 10);
            Assert.IsTrue(0 <= number.ThirdDigit && number.ThirdDigit < 10);
            Assert.IsTrue(0 <= number.FourthDigit && number.FourthDigit < 10);
        }

        [TestMethod]
        public void NumberParameterlessConstructorCorrectTest5()
        {
            GameNumber number = new GameNumber();
            Assert.IsTrue(0 <= number.FirstDigit && number.FirstDigit < 10);
            Assert.IsTrue(0 <= number.SecondDigit && number.SecondDigit < 10);
            Assert.IsTrue(0 <= number.ThirdDigit && number.ThirdDigit < 10);
            Assert.IsTrue(0 <= number.FourthDigit && number.FourthDigit < 10);
        }


    }
}
