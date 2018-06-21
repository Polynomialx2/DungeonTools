using System;
using System.Collections.Generic;
using AppKit;

namespace DungeonTools.Models
{
    public class CharacterInitiativeListDataSource : NSTableViewDataSource
    {
        public List<CharacterEntry> CharacterEntries = new List<CharacterEntry>();

        public CharacterInitiativeListDataSource()
        {
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return CharacterEntries.Count;
        }
    }
}
