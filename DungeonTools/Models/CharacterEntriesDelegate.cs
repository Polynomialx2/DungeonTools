using System;
using AppKit;
using DungeonTools.Helpers;

namespace DungeonTools.Models
{
    public class CharacterEntriesDelegate : NSTableViewDelegate
    {
        private string CellIdentifier = DungeonToolsConstants.ENCOUNTER_PC_CELL_IDENTIFIER;
        private CharacterInitiativeListDataSource DataSource;

        public CharacterEntriesDelegate(CharacterInitiativeListDataSource datasource)
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
                case DungeonToolsConstants.ENCOUNTER_PC_NAME_COLUMN:
                    string characterName = DataSource.CharacterEntries[(int)row].Name;
                    string playerName = DataSource.CharacterEntries[(int)row].PlayerName;
                    view.StringValue = $"{characterName} ({playerName})";
                    break;
                case DungeonToolsConstants.ENCOUNTER_PC_INITIATIVE_COLUMN:
                    view.StringValue = DataSource.CharacterEntries[(int)row].Initiative.ToString();
                    break;
            }

            return view;
        }
    }
}
