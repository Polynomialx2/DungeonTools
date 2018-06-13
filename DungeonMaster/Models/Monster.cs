using System;
using DungeonMaster.Helpers;

namespace DungeonMaster.Models
{
    public class Monster : Character
    {
        private string _hitDice = String.Empty;
        private int _hitPoints = 0;

        public string HitDice { 
            get => _hitDice;
            set {
                if (RollDice.ValidateDiceString(value)) {
                    _hitDice = value;
                } else {
                    _hitDice = String.Empty;
                    throw new InvalidRollException($"Invalid dice format: {value}");
                }
            }
        }
        public int HitPoints { get => _hitPoints; set => _hitPoints = value; }

        public Monster(string name, int initiativeModifier)
        {
            base.Name = name;
            base.InitiativeModifier = initiativeModifier;
        }

        /**
         * Rolls initiative for the monster
         */

        public void RollInitiative() {
            base.Initiative = RollDice.Roll(DungeonMasterConstants.D20) + InitiativeModifier;
        }
    }
}
