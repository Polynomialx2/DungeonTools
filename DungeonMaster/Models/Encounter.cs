using System;
using System.Collections.Generic;

namespace DungeonMaster.Models
{
    public class Encounter
    {
        List<PlayerCharacter> _party = new List<PlayerCharacter>();
        List<Monster> _monsters = new List<Monster>();
        List<string> _initiativeOrder = new List<string>();

        public Encounter()
        {
        }

        public List<PlayerCharacter> Party { get => _party; }
        public List<Monster> Monsters { get => _monsters; set => _monsters = value; }
        public List<string> InitiativeOrder { get => _initiativeOrder; }

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
            foreach (PlayerCharacter character in Party) {
                _initiativeOrder.Add(character.Name);
            }
            foreach (Monster monster in _monsters) {
                _initiativeOrder.Add(monster.Name);
            }
        }
    }
}
