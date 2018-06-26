using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using DungeonTools.Models;

namespace DungeonTools.Controllers
{
    public partial class AddMonsterViewController : AppKit.NSViewController
    {
        private AddNewMonsterHandler _addNewMonsterHandler;
        public AddNewMonsterHandler AddNewMonsterHandler { get => _addNewMonsterHandler; set => _addNewMonsterHandler = value; }

        #region Constructors

        // Called when created from unmanaged code
        public AddMonsterViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AddMonsterViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AddMonsterViewController() : base("AddMonsterView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AddMonsterView View
        {
            get
            {
                return (AddMonsterView)base.View;
            }
        }
    }
}
