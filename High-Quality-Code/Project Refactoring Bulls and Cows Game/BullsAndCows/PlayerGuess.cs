using System;

namespace BullsAndCows
{
    /// <summary>
    /// Represents a single guess made by the player.
    /// </summary>
    public class PlayerGuess : Number
    {
        public PlayerGuess(byte firstDigit, byte secondDigit, byte thirdDigit, byte fourthDigit)
            : base(firstDigit, secondDigit, thirdDigit, fourthDigit)
        {
        }

        public static PlayerGuess TryToParse(string value)
        {
            int number;
            bool result = int.TryParse(value, out number);
            if (result)
            {
                byte[] numbers = new byte[4];
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    numbers[i] = (byte)(number % 10);
                    number = number / 10;
                }
                return new PlayerGuess(numbers[0], numbers[1], numbers[2], numbers[3]);
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}