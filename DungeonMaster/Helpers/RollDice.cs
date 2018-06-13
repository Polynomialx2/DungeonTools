using System;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DungeonMaster.Helpers
{
    public static class RollDice
    {
        private static int numberOfDice;
        private static int diceType;
        private static int modifier = 0;

        /*
         * Returns the result of rolling the given dice string
         * 
         * dice: The dice string in format xdy+z
         */

        public static int Roll(string dice)
        {
            ParseDiceString(dice);
            return CalculateDiceValue();

        }

        /*
         * Calculates the value of the dice roll
         */

        private static int CalculateDiceValue()
        {
            int value = 0;
            Random random = new Random();
            for (int i = 0; i < numberOfDice; i++) {
                value += random.Next(1, diceType);
            }
            return value + modifier;
        }

        /**
         * Parses the dice string and sets member variables
         */

        private static void ParseDiceString(string diceString) {
            numberOfDice = GetNumberOfDice(diceString.ToLower());
            SetDiceType(diceString.ToLower());
            SetModifier(diceString.ToLower());
        }

        /**
         * Sets the modifier value
         * 
         * diceString: The dice string in format xdy+z
         */

        private static void SetModifier(string diceString)
        {
            int value = 0;
            int startPos = GetModifierStartingLocation(diceString);
            if (startPos != diceString.Length) 
            {
                try
                {
                    value = Convert.ToInt32(diceString.Substring(startPos, diceString.Length - startPos));
                } 
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                        throw new InvalidRollException($"Invalid dice roll: {diceString}", ex);
                    throw;
                }
            }
            modifier = value;
        }

        /**
         * Sets the dice type
         * 
         * diceString: the dice string in format xdy+z
         */

        private static void SetDiceType(string diceString)
        {
            int startPos = diceString.IndexOf('d');
            if (startPos == -1)
            {
                throw new InvalidRollException($"Invalid dice roll: {diceString}");
            }
            else
            {
                startPos += 1;
            }
            try
            {
                int endingPos = GetModifierStartingLocation(diceString);
                diceType = Convert.ToInt32(diceString.Substring(startPos, endingPos - startPos));
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    throw new InvalidRollException($"Invalid dice roll: {diceString}", ex);
                throw;
            }
        }

        /**
         * Gets the starting index for the modifier value
         * 
         * diceString: the dice string in format xdy+z
         */

        private static int GetModifierStartingLocation(string diceString)
        {
            int location = diceString.IndexOf('+');
            if (location == -1) 
            {
                location = diceString.IndexOf('-');
                if (location == -1) 
                {
                    location = diceString.Length;
                }
            }
            return location;
        }

        /**
         * Gets the number of dice specified in the dice string
         * 
         * diceString: the dice string in format xdy+z
         */

        private static int GetNumberOfDice(string diceString)
        {
            int number = 1;
            int endingPos = diceString.IndexOf('d');
            if (endingPos == -1)
            {
                throw new InvalidRollException($"Invalid dice roll: {diceString}");
            }
            try 
            {
                if (endingPos != 0)
                {
                    number = Convert.ToInt32(diceString.Substring(0, endingPos));
                }
            } catch(Exception ex) 
            {
                if (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    throw new InvalidRollException($"Invalid dice roll: {diceString}", ex);
                throw;
            }
            return number;
        }

        public static bool ValidateDiceString(string diceString)
        {
            return new Regex(DungeonMasterConstants.REGEX_VALIDATE_DICE_STRING).IsMatch(diceString);
        }
    }

    [Serializable]
    public class InvalidRollException : Exception
    {
        public InvalidRollException()
        {
        }

        public InvalidRollException(string message) : base(message)
        {
        }

        public InvalidRollException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRollException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
