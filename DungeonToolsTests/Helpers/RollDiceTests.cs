using NUnit.Framework;
using System;
using DungeonTools.Helpers;
using System.Collections.Generic;

namespace DungeonToolsTests.Helpers
{
    [TestFixture()]
    public class RollDiceTests
    {
        [Test()]
        public void RollAnInvalidDiceString()
        {
            Assert.Throws<InvalidRollException>(() => RollDice.Roll(""));
        }

        [Test()]
        public void RollAnInvalidNumberOfDice()
        {
            Assert.Throws<InvalidRollException>(() => RollDice.Roll("xd12+1"));
        }

        [Test()]
        public void RollAnInvalidDiceType()
        {
            Assert.Throws<InvalidRollException>(() => RollDice.Roll("5da1+3"));
        }

        [Test()]
        public void RollAnInvalidModifier()
        {
            Assert.Throws<InvalidRollException>(() => RollDice.Roll("2d10+x"));
        }

        [Test()]
        public void RollAValidDiceString()
        {
            var rollValue = RollDice.Roll("1d6+10");
            Assert.IsTrue(rollValue >= 11 && rollValue <= 16);
        }

        [Test()]
        public void RollAValidDiceStringWithoutModifier() {
            var rollValue = RollDice.Roll("1d20");
            Assert.IsTrue(rollValue >= 1 && rollValue <= 20);
        }

        [Test()]
        public void RollManyTimesAndVerifyRange() {
            List<int> rolls = new List<int>();
            for (int i = 0; i < 40; i++)
            {
                rolls.Add(RollDice.Roll("1d4"));
            }
            foreach (int i in rolls) 
            {
                Assert.IsTrue(i >= 1 && i <= 4);
            }
        }

        [Test()]
        public void ValidateDiceString_ShouldValidateGoodStrings() {
            Assert.IsTrue(RollDice.ValidateDiceString("1d6"));
            Assert.IsTrue(RollDice.ValidateDiceString("10d12+25"));
            Assert.IsTrue(RollDice.ValidateDiceString("2d8-6"));
        }

        [Test()]
        public void ValidateDiceString_ShouldNotValidateBadStrings() {
            Assert.IsFalse(RollDice.ValidateDiceString("0d8"));
            Assert.IsFalse(RollDice.ValidateDiceString("1a8"));
            Assert.IsFalse(RollDice.ValidateDiceString("2d10a3"));
            Assert.IsFalse(RollDice.ValidateDiceString(""));
        }
    }
}
