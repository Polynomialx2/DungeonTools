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
		AppKit.NSTableView PartyTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PartyTable != null) {
				PartyTable.Dispose ();
				PartyTable = null;
			}
		}
	}
}
