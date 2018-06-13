using System;
namespace DungeonMaster.Models
{
    public class Monster : Character
    {
        public Monster(string name, int initiativeModifier)
        {
            base.Name = name;
            base.InitiativeModifier = initiativeModifier;
        }

        public void rollInitiative() {
            base.Initiative = InitiativeModifier;
        }
    }
}
