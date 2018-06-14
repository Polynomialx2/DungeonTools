using NUnit.Framework;
using System;
using DungeonTools.Models;
using System.Collections.Generic;

namespace DungeonToolsTests.Models
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

        [Test()]
        public void CanAddMonstersToEncounter() {
            Encounter encounter = new Encounter();
            Monster beholder = new Monster("Beholder", 6);
            encounter.addMonster(beholder);
            Assert.IsTrue(encounter.Monsters.Count == 1);
        }

        [Test()]
        public void CanClearMonsters()
        {
            Encounter encounter = new Encounter();
            Monster beholder = new Monster("Beholder", 6);
            encounter.addMonster(beholder);
            Assert.IsTrue(encounter.Monsters.Count == 1);
            encounter.clearMonsters();
            Assert.IsTrue(encounter.Monsters.Count == 0);
        }

        [Test()]
        public void CanStartEncounter() {
            Encounter encounter = setUpGoodEncounter();
            encounter.start();
            Assert.IsTrue(encounter.InitiativeOrder.Count != 0);
        }

        [Test()]
        public void StartingEncounterPutsInitiativeInCorrectOrder() {
            Encounter encounter = setUpGoodEncounter();
            encounter.start();
            int initiative = 0;
            foreach (Creature c in encounter.InitiativeOrder) {
                Assert.IsTrue(c.Initiative >= initiative);
                initiative = c.Initiative;
            }
        }

        private Encounter setUpGoodEncounter() {
            Encounter encounter = new Encounter();
            encounter.addPC(new PlayerCharacter("Gerald", 11, "Brian"));
            encounter.addPC(new PlayerCharacter("Kresh", 10, "Jason"));
            encounter.addMonster(new Monster("Beholder", 6));
            return encounter;
        }
    }
}
