using System;
namespace DungeonTools.Models
{
    public class CharacterEntry
    {
        public PlayerCharacter character = new PlayerCharacter();

        public CharacterEntry()
        {
        }

        public CharacterEntry(string name, int initiative, string playerName)
        {
            this.character.Name = name;
            this.character.Initiative = initiative;
            this.character.PlayerName = playerName;
        }
    }
}
