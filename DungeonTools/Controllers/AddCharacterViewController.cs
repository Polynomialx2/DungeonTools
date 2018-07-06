using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using DungeonTools.Models;

namespace DungeonTools.Controllers
{
    public partial class AddCharacterViewController : AppKit.NSViewController
    {
        private AddNewCharacterHandler _addNewCharacterHandler;
        public AddNewCharacterHandler AddNewCharacterHandler { get => _addNewCharacterHandler; set => _addNewCharacterHandler = value; }

        #region Constructors

        // Called when created from unmanaged code
        public AddCharacterViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AddCharacterViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AddCharacterViewController() : base("AddCharacterView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AddCharacterView View
        {
            get
            {
                return (AddCharacterView)base.View;
            }
        }

        partial void OnSaveButtonClicked(NSObject sender)
        {
            if (_addNewCharacterHandler != null && InputsAreValid())
            {
                _addNewCharacterHandler(new PlayerCharacter(CharacterName.StringValue, RolledInitiative.IntValue, PlayerName.StringValue));
                DismissViewController(this);
            }
        }

        private bool InputsAreValid()
        {
            bool characterNameIsValid = !CharacterName.StringValue.Equals(String.Empty);
            bool initiativeIsValid = !RolledInitiative.StringValue.Equals(String.Empty);
            bool playerNameIsValid = !PlayerName.StringValue.Equals(String.Empty);
            return characterNameIsValid && initiativeIsValid && playerNameIsValid;
        }
    }
}
