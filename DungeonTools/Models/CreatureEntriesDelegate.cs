using System;
using AppKit;
using DungeonTools.Helpers;

namespace DungeonTools.Models
{
    public class CreatureEntriesDelegate : NSTableViewDelegate
    {
        private string CellIdentifier = DungeonToolsConstants.ENCOUNTER_INITIATIVE_CELL_IDENTIFIER;
        private InitiativeOrderListDataSource DataSource;

        public CreatureEntriesDelegate(InitiativeOrderListDataSource datasource)
        {
            this.DataSource = datasource;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            // This pattern allows you reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view.
            // If a non-null view is returned, you modify it enough to reflect the new data.
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = true;
                view.Editable = true;
            }

            // Set up view based on the column and row
            switch (tableColumn.Identifier)
            {
                case DungeonToolsConstants.ENCOUNTER_INITIATIVE_ORDER_NAME:
                    view.StringValue = DataSource.CreatureEntries[(int)row].Name;
                    view.Editable = true;
                    break;
                case DungeonToolsConstants.ENCOUNTER_INITIATIVE_ORDER_INITIATIVE:
                    view.StringValue = DataSource.CreatureEntries[(int)row].Initiative.ToString();
                    break;
                case DungeonToolsConstants.ENCOUNTER_INITIATIVE_HIT_POINTS:
                    view.Editable = true;
                    var creature = DataSource.CreatureEntries[(int)row];
                    if (creature is Monster)
                    {
                        view.StringValue = ((Monster)creature).HitPoints.ToString();
                    }
                    else
                    {
                        view.StringValue = String.Empty;
                    }
                    break;
            }
            return view;
        }
    }
}
