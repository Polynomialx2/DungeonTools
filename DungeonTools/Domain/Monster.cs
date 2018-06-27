using System;
using DungeonTools.Helpers;

namespace DungeonTools.Models
{
    public class Monster : Creature
    {
        private string _hitDice = String.Empty;
        private int _hitPoints = 0;

        public string HitDice
        {
            get => _hitDice;
            set
            {
                if (RollDice.ValidateDiceString(value))
                {
                    _hitDice = value;
                }
                else
                {
                    _hitDice = String.Empty;
                    throw new InvalidRollException($"Invalid dice format: {value}");
                }
            }
        }
        public int HitPoints { get => _hitPoints; set => _hitPoints = value; }

        public Monster(string name, string hitDice, int initiativeModifier)
        {
            base.Name = name;
            base.InitiativeModifier = initiativeModifier;
            _hitDice = hitDice;
        }

        /*
         * Rolls initiative for the monster
         */

        public void RollInitiative()
        {
            base.Initiative = RollDice.Roll(DungeonToolsConstants.D20) + InitiativeModifier;
        }

        /*
         * Rolls hit points for the monster
         */

        public void RollHitPoints()
        {
            HitPoints = RollDice.Roll(HitDice);
        }
    }
}
