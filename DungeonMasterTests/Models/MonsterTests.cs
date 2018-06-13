using NUnit.Framework;
using System;
using DungeonMaster.Models;

namespace DungeonMasterTests.Models
{
    [TestFixture()]
    public class MonsterTests
    {
        [Test()]
        public void CanRollInitiativeForMonster()
        {
            var beholder = new Monster("Beholder", 6);
            beholder.rollInitiative();
            Assert.AreNotEqual(beholder.Initiative, null);
        }
    }
}
