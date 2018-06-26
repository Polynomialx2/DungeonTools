using System;
using AppKit;
using DungeonTools.Helpers;

namespace DungeonTools.Models
{
    public class MonsterEntriesDelegate : NSTableViewDelegate
    {
        private string CellIdentifier = DungeonToolsConstants.ENCOUNTER_MONSTER_CELL_IDENTIFIER;
        private MonsterInitiativeListDataSource DataSource;

        public MonsterEntriesDelegate(MonsterInitiativeListDataSource datasource)
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
                view.Selectable = false;
                view.Editable = false;
            }

            // Set up view based on the column and row
            switch (tableColumn.Title)
            {
                case DungeonToolsConstants.ENCOUNTER_MONSTER_NAME_COLUMN:
                    view.StringValue = DataSource.MonsterEntries[(int)row].Name;
                    break;
                case DungeonToolsConstants.ENCOUNTER_MONSTER_INITIATIVE_COLUMN:
                    view.StringValue = DataSource.MonsterEntries[(int)row].Initiative.ToString();
                    break;
                case DungeonToolsConstants.ENCOUNTER_MONSTER_INITIATIVE_MODIFIER_COLUMN:
                    int modifier = DataSource.MonsterEntries[(int)row].InitiativeModifier;
                    //view.StringValue = modifier.ToString("+0;-#");
                    view.StringValue = modifier.ToString();
                    break;
                case DungeonToolsConstants.ENCOUNTER_MONSTER_HIT_POINTS_COLUMN:
                    view.StringValue = DataSource.MonsterEntries[(int)row].HitPoints.ToString();
                    break;
                case DungeonToolsConstants.ENCOUNTER_MONSTER_HIT_DICE_COLUMN:
                    view.StringValue = DataSource.MonsterEntries[(int)row].HitDice;
                    break;
            }

            return view;
        }
    }
}