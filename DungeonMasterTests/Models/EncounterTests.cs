using NUnit.Framework;
using System;
using DungeonMaster.Models;

namespace DungeonMasterTests.Models
{
    [TestFixture()]
    public class EncounterTests
    {
        [Test()]
        public void CanAddPlayerCharactersToEncounter() {
            Encounter encounter = new Encounter();
            PlayerCharacter kresh = new PlayerCharacter("Kresh", 9, "Jason");
            encounter.addPC(kresh);
            Assert.IsTrue(encounter.Party.Count == 1);
        }

        [Test()]
        public void CanClearParty()
        {
            Encounter encounter = new Encounter();
            PlayerCharacter kresh = new PlayerCharacter("Kresh", 9, "Jason");
            encounter.addPC(kresh);
            Assert.IsTrue(encounter.Party.Count == 1);
            encounter.clearParty();
            Assert.IsTrue(encounter.Party.Count == 0);
        }
    }
}
