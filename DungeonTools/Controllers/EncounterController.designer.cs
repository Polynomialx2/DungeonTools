// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DungeonTools
{
	[Register ("EncounterController")]
	partial class EncounterController
	{
		[Outlet]
		AppKit.NSButton EndEncounterButton { get; set; }

		[Outlet]
		AppKit.NSTableView InitiativeTable { get; set; }

		[Outlet]
		AppKit.NSTableView MonsterTable { get; set; }

		[Outlet]
		AppKit.NSTableView PartyTable { get; set; }

		[Outlet]
		AppKit.NSButton StartEncounterButton { get; set; }

		[Action ("OnAddMonsterButtonClicked:")]
		partial void OnAddMonsterButtonClicked (Foundation.NSObject sender);

		[Action ("OnAddPlayerButtonClicked:")]
		partial void OnAddPlayerButtonClicked (Foundation.NSObject sender);

		[Action ("OnClearMonstersButtonClicked:")]
		partial void OnClearMonstersButtonClicked (Foundation.NSObject sender);

		[Action ("OnEndEncounterButtonClicked:")]
		partial void OnEndEncounterButtonClicked (Foundation.NSObject sender);

		[Action ("OnRemoveButtonClicked:")]
		partial void OnRemoveButtonClicked (Foundation.NSObject sender);

		[Action ("OnRemoveMonsterButtonClicked:")]
		partial void OnRemoveMonsterButtonClicked (Foundation.NSObject sender);

		[Action ("OnRemovePlayerButtonClicked:")]
		partial void OnRemovePlayerButtonClicked (Foundation.NSObject sender);

		[Action ("OnStartEncounterButtonClicked:")]
		partial void OnStartEncounterButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (EndEncounterButton != null) {
				EndEncounterButton.Dispose ();
				EndEncounterButton = null;
			}

			if (InitiativeTable != null) {
				InitiativeTable.Dispose ();
				InitiativeTable = null;
			}

			if (MonsterTable != null) {
				MonsterTable.Dispose ();
				MonsterTable = null;
			}

			if (PartyTable != null) {
				PartyTable.Dispose ();
				PartyTable = null;
			}

			if (StartEncounterButton != null) {
				StartEncounterButton.Dispose ();
				StartEncounterButton = null;
			}
		}
	}
}
