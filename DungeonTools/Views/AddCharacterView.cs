using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DungeonTools.Controllers
{
    public partial class AddCharacterView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AddCharacterView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AddCharacterView(NSCoder coder) : base(coder)
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
