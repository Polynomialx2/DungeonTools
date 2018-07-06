using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using DungeonTools.Models;
using DungeonTools.Helpers;

namespace DungeonTools.Controllers
{
    public partial class AddMonsterViewController : NSViewController, INSTextFieldDelegate
    {
        private AddNewMonsterHandler _addNewMonsterHandler;
        private bool diceStringIsValid = false;
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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            MonsterHitDice.Delegate = this;
            InvalidDiceStringField.Hidden = true;
        }

        // Add the monsters to the list

        partial void OnSaveButtonClicked(NSObject sender)
        {
            if (_addNewMonsterHandler != null && InputsAreValid())
            {
                int count = MonsterCount.IntValue;
                bool reloadData = false;
                for (int i = 0; i < MonsterCount.IntValue; i++)
                {
                    if (i == (count - 1))
                    {
                        reloadData = true;
                    }
                    string monsterName = $"{MonsterType.StringValue} {i + 1}";
                    Monster monster = new Monster(MonsterType.StringValue, MonsterHitDice.StringValue, MonsterInitiative.IntValue);
                    monster.Name = monsterName;
                    _addNewMonsterHandler(monster, reloadData);
                }
                DismissViewController(this);
            }
        }

        // Validate the dice string as it's entered

        [Export("controlTextDidChange:")]
        public void Changed(NSNotification notification)
        {
            string diceString = MonsterHitDice.StringValue;
            if (RollDice.ValidateDiceString(diceString))
            {
                diceStringIsValid = true;
                InvalidDiceStringField.Hidden = true;
            }
            else
            {
                diceStringIsValid = false;
                InvalidDiceStringField.Hidden = false;
            }
        }

        // Validate the inputs. 

        private bool InputsAreValid()
        {
            bool monsterTypeValid = !MonsterType.StringValue.Equals(String.Empty);
            bool monsterCountValid = !MonsterCount.StringValue.Equals(String.Empty);
            bool monsterInitiativeValid = !MonsterInitiative.StringValue.Equals(String.Empty);
            return diceStringIsValid && monsterTypeValid && monsterCountValid && monsterInitiativeValid;
        }
    }
}
