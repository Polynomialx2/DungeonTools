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
	[Register ("AddMonsterViewController")]
	partial class AddMonsterViewController
	{
		[Outlet]
		AppKit.NSTextField MonsterCount { get; set; }

		[Outlet]
		AppKit.NSTextField MonsterHitDice { get; set; }

		[Outlet]
		AppKit.NSTextField MonsterInitiative { get; set; }

		[Outlet]
		AppKit.NSTextField MonsterType { get; set; }

		[Action ("OnCancelButtonClicked:")]
		partial void OnCancelButtonClicked (Foundation.NSObject sender);

		[Action ("OnSaveButtonClicked:")]
		partial void OnSaveButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (MonsterCount != null) {
				MonsterCount.Dispose ();
				MonsterCount = null;
			}

			if (MonsterInitiative != null) {
				MonsterInitiative.Dispose ();
				MonsterInitiative = null;
			}

			if (MonsterType != null) {
				MonsterType.Dispose ();
				MonsterType = null;
			}

			if (MonsterHitDice != null) {
				MonsterHitDice.Dispose ();
				MonsterHitDice = null;
			}
		}
	}
}
