using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DungeonTools.Controllers
{
    public partial class EncounterView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public EncounterView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EncounterView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
