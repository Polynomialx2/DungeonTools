using System;
using System.Collections.Generic;
using AppKit;
using DungeonTools.Helpers;
using Foundation;

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

        // Overrides required for drag and drop

        public override bool WriteRows(NSTableView tableView, Foundation.NSIndexSet rowIndexes, NSPasteboard pboard)
        {
            NSData data = NSKeyedArchiver.ArchivedDataWithRootObject(rowIndexes);
            pboard.DeclareTypes(new string[] { DungeonToolsConstants.ECOUNTER_INITIATIVE_DRAG_DROP_TYPE }, this);
            pboard.SetDataForType(data, DungeonToolsConstants.ECOUNTER_INITIATIVE_DRAG_DROP_TYPE);
            return true;
        }

        public override NSDragOperation ValidateDrop(NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation)
        {
            tableView.SetDropRowDropOperation(row, dropOperation);
            return NSDragOperation.Move;
        }

        public override bool AcceptDrop(NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation)
        {
            NSData rowData = info.DraggingPasteboard.GetDataForType(DungeonToolsConstants.ECOUNTER_INITIATIVE_DRAG_DROP_TYPE);
            if (rowData == null)
            {
                return false;
            }
            NSIndexSet dataArray = NSKeyedUnarchiver.UnarchiveObject(rowData) as NSIndexSet;
            tableView.BeginUpdates();
            SwapCreatures(dataArray, (int)row);
            tableView.ReloadData();
            tableView.EndUpdates();
            return true;
        }

        private void SwapCreatures(NSIndexSet creatureIndexes, int row)
        {
            int startIndex = (int)creatureIndexes.FirstIndex;
            int endIndex = (int)creatureIndexes.LastIndex;
            for (int index = startIndex; index <= endIndex; index++)
            {
                Creature creatureToSwap = CreatureEntries[index];
                CreatureEntries.RemoveAt(index);
                if (CreatureEntries.Count == (row - 1))
                {
                    CreatureEntries.Insert(row - 1, creatureToSwap);
                }
                else
                {
                    CreatureEntries.Insert(row, creatureToSwap);
                }
                row++;
            }
        }
    }
}
