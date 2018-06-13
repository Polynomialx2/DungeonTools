using System;
using System.Collections.Generic;

namespace DungeonMaster.Models
{
    public class Encounter
    {
        List<PlayerCharacter> _party = new List<PlayerCharacter>();

        public Encounter()
        {
        }

        public List<PlayerCharacter> Party { get => _party; }

        /*
         * Adds player character to the party
         */

        public void addPC(PlayerCharacter character) {
            Party.Add(character);
        }

        public void clearParty() {
            Party.Clear();
        }
    }
}
