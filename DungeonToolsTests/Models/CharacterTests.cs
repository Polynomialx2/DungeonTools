using NUnit.Framework;
using System;
using DungeonTools.Models;

namespace DungeonToolsTests.Models
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
