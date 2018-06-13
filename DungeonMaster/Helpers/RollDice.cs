using System;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DungeonMaster.Helpers
{
    public static class RollDice
    {
        /*
         * Returns the result of rolling the given dice string
         * 
         * dice: The dice string in format xdy+z
         */

        public static int Roll(string dice)
        {
            dice = dice.ToLower();
            if (ValidateDiceString(dice))
            {
                int numberOfDice = GetNumberOfDice(dice);
                int diceType = GetDiceType(dice);
                int modifier = GetModifier(dice);
                return CalculateDiceValue(numberOfDice, diceType, modifier);
            }
            else
            {
                throw new InvalidRollException($"Invalid dice roll: {dice}");
            }
        }

        public static bool ValidateDiceString(string diceString)
        {
            return new Regex(DungeonMasterConstants.REGEX_VALIDATE_DICE_STRING).IsMatch(diceString);
        }

        /*
         * Calculates the value of the dice roll
         */

        private static int CalculateDiceValue(int numberOfDice, int diceType, int modifier)
        {
            int value = 0;
            Random random = new Random();
            for (int i = 0; i < numberOfDice; i++) {
                value += random.Next(1, diceType);
            }
            return value + modifier;
        }

        /**
         * Sets the modifier value
         * 
         * diceString: The dice string in format xdy+z
         */

        private static int GetModifier(string diceString)
        {
            Regex regex = new Regex(DungeonMasterConstants.REGEX_MODIFIER);
            int value = 0;
            string diceModifier = regex.Match(diceString).Value;
            if (diceModifier != String.Empty) {
                try {
                    value = Convert.ToInt32(diceModifier);
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                        throw new InvalidRollException($"Invalid dice roll: {diceString}", ex);
                    throw;
                }
            }
            return value;
        }

        /**
         * Sets the dice type
         * 
         * diceString: the dice string in format xdy+z
         */

        private static int GetDiceType(string diceString)
        {
            Regex regex = new Regex(DungeonMasterConstants.REGEX_DICE_TYPE);
            int diceType;
            try {
                diceType = Convert.ToInt32(regex.Match(diceString).Value);
                return diceType;
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    throw new InvalidRollException($"Invalid dice roll: {diceString}", ex);
                throw;
            }
        }

        /**
         * Gets the number of dice specified in the dice string
         * 
         * diceString: the dice string in format xdy+z
         */

        private static int GetNumberOfDice(string diceString)
        {
            Regex regex = new Regex(DungeonMasterConstants.REGEX_NUMBER_OF_DICE);
            int number;
            try
            {
                number = Convert.ToInt32(regex.Match(diceString).Value);
            } catch (Exception ex)
            {
                if (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    throw new InvalidRollException($"Invalid dice roll: {diceString}", ex);
                throw;
            }
            return number;
        }
    }

    [Serializable]
    public class InvalidRollException : Exception
    {
        public InvalidRollException() {}

        public InvalidRollException(string message) : base(message) {}

        public InvalidRollException(string message, Exception innerException) : base(message, innerException) {}

        protected InvalidRollException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
