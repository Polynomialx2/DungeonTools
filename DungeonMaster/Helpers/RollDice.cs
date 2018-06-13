using System;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

namespace DungeonMaster.Helpers
{
    public static class RollDice
    {
        private static int numberOfDice;
        private static int diceType;
        private static int modifier = 0;

        public static int Roll(string dice)
        {
            ParseDiceString(dice);
            return CalculateDiceValue();

        }

        private static int CalculateDiceValue()
        {
            var value = 0;
            Random random = new Random();
            for (int i = 0; i < numberOfDice; i++) {
                value += random.Next(1, diceType);
            }
            return value + modifier;
        }

        private static void ParseDiceString(string diceString) {
            numberOfDice = GetNumberOfDice(diceString.ToLower());
            SetDiceType(diceString.ToLower());
            SetModifier(diceString.ToLower());
        }

        private static void SetModifier(string diceString)
        {
            var value = 0;
            var startPos = GetModifierStartingLocation(diceString);
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

        private static void SetDiceType(string diceString)
        {
            var startPos = diceString.IndexOf('d');
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

        private static int GetModifierStartingLocation(string diceString)
        {
            var location = diceString.IndexOf('+');
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

        private static int GetNumberOfDice(string diceString)
        {
            var number = 1;
            var endingPos = diceString.IndexOf('d');
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
