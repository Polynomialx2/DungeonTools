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
            Monster beholder = new Monster("Beholder", 6);
            beholder.RollInitiative();
            Assert.IsTrue(beholder.Initiative >= 7 && beholder.Initiative <= 26);
        }
    }
}
