using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class PlayerGuessTests
    {
        [TestMethod]
        public void NumberParametersConstructorCorrectTest()
        {
            PlayerGuess number = new PlayerGuess(1, 2, 3, 4);
            Assert.AreEqual(1, number.FirstDigit);
            Assert.AreEqual(2, number.SecondDigit);
            Assert.AreEqual(3, number.ThirdDigit);
            Assert.AreEqual(4, number.FourthDigit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberConstructorFirstDigitAboveLimitTest()
        {
            PlayerGuess number = new PlayerGuess(10, 2, 3, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberConstructorSecondDigitAboveLimitTest()
        {
            PlayerGuess number = new PlayerGuess(1, 10, 3, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberConstructorThirdDigitAboveLimitTest()
        {
            PlayerGuess number = new PlayerGuess(1, 2, 10, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberConstructorFourthDigitAboveLimitTest()
        {
            PlayerGuess number = new PlayerGuess(1, 2, 3, 10);
        }

        [TestMethod]
        public void TryToParsePlayerGuessMethodMethodCorrectTest()
        {
            PlayerGuess expected = new PlayerGuess(5, 6, 7, 8);
            PlayerGuess result = PlayerGuess.TryToParse("5678");
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToParsePlayerGuessMethodIncorrectInputTest()
        {
            PlayerGuess.TryToParse("wrong");
        }
    }
}
