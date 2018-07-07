using System;
namespace DungeonTools.Helpers
{
    public static class DungeonToolsConstants
    {
        // Abilities
        public const string STRENGTH = "Strength";
        public const string DEXTERITY = "Dexterity";
        public const string CONSTITUTION = "Constitution";
        public const string INTELLIGENCE = "Intelligence";
        public const string WISDOM = "Wisdom";
        public const string CHARISMA = "Charisma";

        // Dice
        public const string D4 = "1d4";
        public const string D6 = "1d6";
        public const string D8 = "1d8";
        public const string D10 = "1d10";
        public const string D12 = "1d12";
        public const string D20 = "1d20";
        public const string D100 = "1d100";

        // Regex
        public const string REGEX_VALIDATE_DICE_STRING = "^[1-9]\\d*(d|D)(((?=[1-9])\\d*$)|((?=[1-9])\\d*(\\+|-)(?=[1-9])\\d*$))";
        public const string REGEX_NUMBER_OF_DICE = "^\\d*";
        public const string REGEX_DICE_TYPE = "(?<=d)\\d*";
        public const string REGEX_MODIFIER = "(?<=(\\+|-))\\d*";

        // Encounter tables
        public const string ENCOUNTER_PC_CELL_IDENTIFIER = "CharacterEntryCell";
        public const string ENCOUNTER_PC_NAME_COLUMN = "Name";
        public const string ENCOUNTER_PC_INITIATIVE_COLUMN = "Initiative";
        public const string ENCOUNTER_MONSTER_CELL_IDENTIFIER = "MonsterEntryCell";
        public const string ENCOUNTER_MONSTER_NAME_COLUMN = "Name";
        public const string ENCOUNTER_MONSTER_INITIATIVE_COLUMN = "Initiative";
        public const string ENCOUNTER_MONSTER_INITIATIVE_MODIFIER_COLUMN = "InitiativeModifier";
        public const string ENCOUNTER_MONSTER_HIT_POINTS_COLUMN = "Hit Points";
        public const string ENCOUNTER_MONSTER_HIT_DICE_COLUMN = "Hit Dice";
        public const string ENCOUNTER_INITIATIVE_CELL_IDENTIFIER = "InitiativeOrderEntryCell";
        public const string ENCOUNTER_INITIATIVE_ORDER_NAME = "Creature Name";
        public const string ENCOUNTER_INITIATIVE_ORDER_INITIATIVE = "Initiative";
        public const string ENCOUNTER_INITIATIVE_HIT_POINTS = "HitPoints";
        public const string ECOUNTER_INITIATIVE_DRAG_DROP_TYPE = "InitiativeDragDropType";

    }
}
