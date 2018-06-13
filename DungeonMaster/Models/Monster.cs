using System;
using DungeonMaster.Helpers;

namespace DungeonMaster.Models
{
    public class Monster : Character
    {
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
