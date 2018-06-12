using NUnit.Framework;
using System;

namespace DungeonMasterTests.Models
{
    [TestFixture()]
    public class CharacterTests
    {
        [Test()]
        public void CanMakeNewCharacter()
        {
            Character character = new Character();
        }
    }
}
