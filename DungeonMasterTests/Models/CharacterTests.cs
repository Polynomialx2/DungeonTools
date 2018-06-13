using NUnit.Framework;
using System;
using DungeonMaster.Models;

namespace DungeonMasterTests.Models
{
    [TestFixture()]
    public class CharacterTests
    {
        [Test()]
        public void CanMakeNewCharacter()
        {
            PlayerCharacter character = new PlayerCharacter("Kresh", 9, "Jason");
        }
    }
}
