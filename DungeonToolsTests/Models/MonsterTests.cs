using NUnit.Framework;
using System;
using DungeonTools.Models;

namespace DungeonToolsTests.Models
{
    [TestFixture()]
    public class MonsterTests
    {
        [Test()]
        public void CanRollInitiativeForMonster()
        {
            Monster beholder = new Monster("Beholder", "1d6", 6);
            beholder.RollInitiative();
            Assert.IsTrue(beholder.Initiative >= 7 && beholder.Initiative <= 26);
        }

        [Test()]
        public void CanRollHitPointsForMonster()
        {
            Monster beholder = new Monster("Beholder", "1d6", 6);
            beholder.HitDice = "11d8+44";
            beholder.RollHitPoints();
            Assert.IsTrue(beholder.HitPoints > 0);
        }
    }
}
