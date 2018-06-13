using System;
using System.Collections.Generic;

namespace DungeonMaster.Models
{
    public class PlayerCharacter : Creature
    {
        private string _playerName;

        public string PlayerName { get => _playerName; set => _playerName = value; }

        public PlayerCharacter(string name, int initiative, string playerName)
        {
            base.Name = name;
            base.Initiative = initiative;
            PlayerName = playerName;
        }
    }
}
