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

        partial void OnSaveButtonClicked(NSObject sender)
        {
            if (_addNewMonsterHandler != null)
            {
                int count = MonsterCount.IntValue;
                bool reloadData = false;
                for (int i = 0; i < MonsterCount.IntValue; i++)
                {
                    if (i == count - 1)
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
    }
}
