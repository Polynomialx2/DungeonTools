using System;
namespace DungeonTools.Helpers
{
    public static class DungeonToolsConstants
    {
        // Abilities
        public static readonly string STRENGTH = "Strength";
        public static readonly string DEXTERITY = "Dexterity";
        public static readonly string CONSTITUTION = "Constitution";
        public static readonly string INTELLIGENCE = "Intelligence";
        public static readonly string WISDOM = "Wisdom";
        public static readonly string CHARISMA = "Charisma";

        // Dice
        public static readonly string D4 = "1d4";
        public static readonly string D6 = "1d6";
        public static readonly string D8 = "1d8";
        public static readonly string D10 = "1d10";
        public static readonly string D12 = "1d12";
        public static readonly string D20 = "1d20";
        public static readonly string D100 = "1d100";

        // Regex
        public static readonly string REGEX_VALIDATE_DICE_STRING = "^[1-9]\\d*(d|D)(((?=[1-9])\\d*$)|((?=[1-9])\\d*(\\+|-)(?=[1-9])\\d*$))";
        public static readonly string REGEX_NUMBER_OF_DICE = "^\\d*";
        public static readonly string REGEX_DICE_TYPE = "(?<=d)\\d*";
        public static readonly string REGEX_MODIFIER = "(?<=(\\+|-))\\d*";
    }
}
