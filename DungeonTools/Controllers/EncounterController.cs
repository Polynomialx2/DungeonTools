// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using DungeonTools.Models;
using DungeonTools.Controllers;

namespace DungeonTools
{
    public delegate void AddNewCharacterHandler(PlayerCharacter character);

	public partial class EncounterController : NSViewController
	{
        private Encounter _encounter = new Encounter();

        public CharacterInitiativeListDataSource characterDataSource = new CharacterInitiativeListDataSource();
        public MonsterInitiativeListDataSource monsterDataSource = new MonsterInitiativeListDataSource();

		public EncounterController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            PartyTable.DataSource = characterDataSource;
            PartyTable.Delegate = new CharacterEntriesDelegate(characterDataSource);
            MonsterTable.DataSource = monsterDataSource;
            MonsterTable.Delegate = new MonsterEntriesDelegate(monsterDataSource);
        }

        public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            switch (segue.Identifier)
            {
                case "SegueToAddCharacter":
                    AddCharacterViewController destinationController = (AddCharacterViewController)segue.DestinationController;
                    destinationController.AddNewCharacterHandler = addCharacterToParty;
                    break;
                default:
                    break;
            }
        }

        partial void OnRemovePlayerButtonClicked(NSObject sender)
        {
            if (PartyTable.SelectedRow != -1)
            {
                characterDataSource.CharacterEntries.RemoveAt((int)PartyTable.SelectedRow);
                PartyTable.ReloadData();
            }
        }

        partial void OnRemoveMonsterButtonClicked(NSObject sender)
        {
            if (MonsterTable.SelectedRow != -1)
            {
                monsterDataSource.MonsterEntries.RemoveAt((int)MonsterTable.SelectedRow);
                MonsterTable.ReloadData();
            }
        }

        private void addCharacterToParty(PlayerCharacter character)
        {
            characterDataSource.CharacterEntries.Add(character);
            PartyTable.ReloadData();
        }


    }
}
