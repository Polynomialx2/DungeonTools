using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<PlayerCharacter> Party { get => _party; set => _party = value; }
        public List<Monster> Monsters { get => _monsters; set => _monsters = value; }
        public List<Creature> InitiativeOrder { get => _initiativeOrder; set => _initiativeOrder = value; }

        /*
         * Adds player character to the party
         */

        public void addPC(PlayerCharacter character)
        {
            Party.Add(character);
        }

        public void clearParty()
        {
            Party.Clear();
        }

        public void endEncounter()
        {
            //clearParty();
            //clearMonsters();
            InitiativeOrder.Clear();
        }

        public void addMonster(Monster monster)
        {
            Monsters.Add(monster);
        }

        public void clearMonsters()
        {
            Monsters.Clear();
        }

        public void start()
        {
            List<Creature> initiativeOrder = new List<Creature>();
            Dictionary<string, int> monsterInitiatives = GetMonsterInitiatives(Monsters);

            initializeMonsters(monsterInitiatives, Monsters);
            initiativeOrder.AddRange(Monsters);
            initiativeOrder.AddRange(Party);

            // Sorts by initiative
            InitiativeOrder = initiativeOrder.OrderByDescending(cw => cw.Initiative).ToList();
        }

        // Prepares monsters for encounter by initializing initiative and hit points

        private void initializeMonsters(Dictionary<string, int> initiatives, List<Monster> monsters)
        {
            foreach (Monster monster in monsters)
            {
                monster.RollHitPoints();
                monster.Initiative = initiatives[monster.Type];
            }
        }

        // Rolls the initiative for each monster type

        private Dictionary<string, int> GetMonsterInitiatives(List<Monster> monsters)
        {
            Dictionary<string, int> initiatives = new Dictionary<string, int>();
            List<string> types = new List<string>();
            foreach (Monster monster in monsters)
            {
                if (!types.Contains(monster.Type))
                {
                    monster.RollInitiative();
                    initiatives.Add(monster.Type, monster.Initiative);
                    types.Add(monster.Type);
                }
            }
            return initiatives;
        }
    }
}
