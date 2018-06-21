// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DungeonTools.Controllers
{
	[Register ("AddCharacterViewController")]
	partial class AddCharacterViewController
	{
		[Outlet]
		AppKit.NSTextField CharacterName { get; set; }

		[Outlet]
		AppKit.NSTextField PlayerName { get; set; }

		[Outlet]
		AppKit.NSTextField RolledInitiative { get; set; }

		[Action ("OnCancelButtonClicked:")]
		partial void OnCancelButtonClicked (Foundation.NSObject sender);

		[Action ("OnSaveButtonClicked:")]
		partial void OnSaveButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (CharacterName != null) {
				CharacterName.Dispose ();
				CharacterName = null;
			}

			if (PlayerName != null) {
				PlayerName.Dispose ();
				PlayerName = null;
			}

			if (RolledInitiative != null) {
				RolledInitiative.Dispose ();
				RolledInitiative = null;
			}
		}
	}
}
