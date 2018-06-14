using System;
using System.Collections.Generic;
using DungeonTools.Helpers;

namespace DungeonTools.Models
{
    public class Encounter
    {
        List<PlayerCharacter> _party = new List<PlayerCharacter>();
        List<Monster> _monsters = new List<Monster>();
        List<Creature> _initiativeOrder = new List<Creature>();

        public Encounter()
        {
        }

        public List<PlayerCharacter> Party { get => _party; }
        public List<Monster> Monsters { get => _monsters; set => _monsters = value; }
        public List<Creature> InitiativeOrder { get => _initiativeOrder; }

        /*
         * Adds player character to the party
         */

        public void addPC(PlayerCharacter character) {
            Party.Add(character);
        }

        public void clearParty() {
            Party.Clear();
        }

        public void addMonster(Monster monster) {
            Monsters.Add(monster);
        }

        public void clearMonsters() {
            Monsters.Clear();
        }

        public void start() {
            InitiativeOrder.Clear();
            foreach (Monster monster in Monsters) {
                monster.RollInitiative();
                InitiativeOrder.Add(monster);
            }
            foreach (PlayerCharacter character in Party) {
                InitiativeOrder.Add(character);
            }
            // Sorts by initiative
            InitiativeOrder.Sort();
        }
    }
}
