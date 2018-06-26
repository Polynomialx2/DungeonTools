using System;
using System.Collections.Generic;
using AppKit;

namespace DungeonTools.Models
{
    public class InitiativeOrderListDataSource : NSTableViewDataSource
    {
        public List<Creature> CreatureEntries = new List<Creature>();

        public InitiativeOrderListDataSource()
        {
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return CreatureEntries.Count;
        }
    }
}
