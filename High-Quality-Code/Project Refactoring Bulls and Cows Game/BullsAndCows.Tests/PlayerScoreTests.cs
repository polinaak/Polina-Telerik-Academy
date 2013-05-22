using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class PlayerScoreTests
    {
        [TestMethod]
        public void PlayerScoreConstructorCorrectTest()
        {
            PlayerScore player = new PlayerScore("Vankata", 5);
            Assert.AreEqual("Vankata", player.PlayerName);
            Assert.AreEqual(5, player.Guesses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreConstructorNullNameTest()
        {
            PlayerScore player = new PlayerScore(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreConstructorEmptyNameTest()
        {
            PlayerScore player = new PlayerScore("", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreConstructorWhitespaceNameTest()
        {
            PlayerScore player = new PlayerScore("    ", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerScoreConstructorNegativeGuessesTest()
        {
            PlayerScore player = new PlayerScore("Vankata", -1);
        }

        [TestMethod]
        public void PlayerScoreSerializeMethodCorrectTest()
        {
            PlayerScore player = new PlayerScore("Vankata", 5);
            Assert.AreEqual("Vankata_:::_5", player.Serialize());
        }

        [TestMethod]
        public void PlayerScoreCompareToMethodCorrectTest()
        {
            PlayerScore player = new PlayerScore("Vankata", 5);
            PlayerScore samePlayer = new PlayerScore("Vankata", 5);
            Assert.AreEqual(0, player.CompareTo(samePlayer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreCompareToMethodNullTest()
        {
            PlayerScore player = new PlayerScore("Vankata", 5);
            Assert.AreEqual(0, player.CompareTo(null));
        }
    }
}
