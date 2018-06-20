using System;
namespace DungeonTools.Models
{
    public class CharacterEntry
    {
        public PlayerCharacter character = new PlayerCharacter();

        public CharacterEntry()
        {
        }

        public CharacterEntry(string name, int initiative)
        {
            this.character.Name = name;
            this.character.Initiative = initiative;
        }
    }
}
