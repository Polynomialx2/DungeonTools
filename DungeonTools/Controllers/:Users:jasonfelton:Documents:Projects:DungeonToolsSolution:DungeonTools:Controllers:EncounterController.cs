using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DungeonTools.Controllers
{
    public partial class EncounterController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public EncounterController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EncounterController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EncounterController() : base("Encounter", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new EncounterView
        {
            get
            {
                return (Encounter)base.View;
            }
        }
    }
}
