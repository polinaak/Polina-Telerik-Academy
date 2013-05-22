using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class CheatTests
    {

        [TestMethod]
        public void CheatInitialStateTest()
        {
            Cheat cheat = new Cheat();
            Assert.AreEqual("XXXX", new string(cheat.CheatNumber));
        }

        [TestMethod]
        public void CheatCountAndFinalStateTest()
        {
            GameNumber theNumber = new GameNumber();
            Cheat cheat = new Cheat();

            cheat.GetCheat(theNumber);
            Assert.AreEqual(1, cheat.Count);

            cheat.GetCheat(theNumber);
            Assert.AreEqual(2, cheat.Count);

            cheat.GetCheat(theNumber);
            Assert.AreEqual(3, cheat.Count);

            cheat.GetCheat(theNumber);
            Assert.AreEqual(4, cheat.Count);

            cheat.GetCheat(theNumber);
            Assert.AreEqual(4, cheat.Count);

            for (int i = 0; i < cheat.CheatNumber.Length; i++)
            {
                Assert.AreNotEqual('X', cheat.CheatNumber[i]);
            }
        }
    }
}
