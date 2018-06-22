using System;
using System.Collections.Generic;
using AppKit;

namespace DungeonTools.Models
{
    public class MonsterInitiativeListDataSource : NSTableViewDataSource
    {
        public List<Monster> MonsterEntries = new List<Monster>();

        public MonsterInitiativeListDataSource()
        {
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return MonsterEntries.Count;
        }
    }
}
