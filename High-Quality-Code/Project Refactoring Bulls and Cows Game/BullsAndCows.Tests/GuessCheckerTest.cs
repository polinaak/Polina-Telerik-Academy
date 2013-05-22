using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class GuessCheckerTest
    {
        [TestMethod]
        public void GetBullsAndCowsMatchesOneBullTest()
        {
            GameNumber theNumber = new GameNumber(1, 2, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(4, 2, 9, 3);
            Result expected = new Result(1, 0);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesNoBullsAndCowsTest()
        {
            GameNumber theNumber = new GameNumber(1, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(4, 2, 9, 3);
            Result expected = new Result(0, 0);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesOneCowTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(4, 2, 9, 3);
            Result expected = new Result(0, 1);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesOneBullandOneCowTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(4, 2, 6, 3);
            Result expected = new Result(1, 1);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesOneBullandTwoCowTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(8, 2, 6, 3);
            Result expected = new Result(1, 2);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }


        [TestMethod]
        public void GetBullsAndCowsMatchesFourBullsTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(3, 0, 6, 8);
            Result expected = new Result(4, 0);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesFourCowsTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(8, 6, 0, 3);
            Result expected = new Result(0, 4);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesThreeBullsTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(3, 0, 6, 9);
            Result expected = new Result(3, 0);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesThreeCowsTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(1, 6, 3, 0);
            Result expected = new Result(0, 3);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesTwoBullsAndTwoCowsTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(3, 6, 0, 8);
            Result expected = new Result(2, 2);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetBullsAndCowsMatchesOneBullsAndTwoCowsTest()
        {
            GameNumber theNumber = new GameNumber(3, 0, 6, 8);
            PlayerGuess playerGuess = new PlayerGuess(1, 6, 0, 8);
            Result expected = new Result(1, 2);
            Result result = GuessChecker.GetBullsAndCowsMatches(playerGuess, theNumber);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }
    }
}
