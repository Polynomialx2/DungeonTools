using System;
namespace DungeonMaster.Models
{
    public abstract class Creature
    {
        private int _initiativeModifier;
        private string _name;
        private int _initiative;

        public int InitiativeModifier { get => _initiativeModifier; set => _initiativeModifier = value; }
        public string Name { get => _name; set => _name = value; }
        public int Initiative { get => _initiative; set => _initiative = value; }
    }
}
