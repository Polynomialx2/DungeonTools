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
		AppKit.NSTableView MonsterTable { get; set; }

		[Outlet]
		AppKit.NSTableView PartyTable { get; set; }

		[Action ("OnAddMonsterButtonClicked:")]
		partial void OnAddMonsterButtonClicked (Foundation.NSObject sender);

		[Action ("OnAddPlayerButtonClicked:")]
		partial void OnAddPlayerButtonClicked (Foundation.NSObject sender);

		[Action ("OnRemoveButtonClicked:")]
		partial void OnRemoveButtonClicked (Foundation.NSObject sender);

		[Action ("OnRemoveMonsterButtonClicked:")]
		partial void OnRemoveMonsterButtonClicked (Foundation.NSObject sender);

		[Action ("OnRemovePlayerButtonClicked:")]
		partial void OnRemovePlayerButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (MonsterTable != null) {
				MonsterTable.Dispose ();
				MonsterTable = null;
			}

			if (PartyTable != null) {
				PartyTable.Dispose ();
				PartyTable = null;
			}
		}
	}
}
