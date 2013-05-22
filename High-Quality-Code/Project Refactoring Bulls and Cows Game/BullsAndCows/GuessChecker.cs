using System;

namespace BullsAndCows
{
    /// <summary>
    /// Checks player guess against game number.
    /// </summary>
    /// <return>An instance of Result</return>
    public static class GuessChecker
    {
        public static Result GetBullsAndCowsMatches(PlayerGuess playerGuess, GameNumber gameNumber)
        {
            int bulls = 0;

            // checks if playerGuess.FirstDigit is a bull:
            bool isFirstDigitBull = false;
            if (gameNumber.FirstDigit == playerGuess.FirstDigit)
            {
                isFirstDigitBull = true;
                bulls++;
            }

            // checks if playerGuess.SecondDigit is a bull:
            bool isSecondDigitBull = false;
            if (gameNumber.SecondDigit == playerGuess.SecondDigit)
            {
                isSecondDigitBull = true;
                bulls++;
            }

            // checks if playerGuess.ThirdDigit is a bull:
            bool isThirdDigitBull = false;
            if (gameNumber.ThirdDigit == playerGuess.ThirdDigit)
            {
                isThirdDigitBull = true;
                bulls++;
            }

            // checks if playerGuess.FourthDigit is a bull:
            bool isFourthDigitBull = false;
            if (gameNumber.FourthDigit == playerGuess.FourthDigit)
            {
                isFourthDigitBull = true;
                bulls++;
            }

            int cows = 0;

            // checks if playerGuess.playerGuess.FirstDigit is cow:
            if (!isFirstDigitBull)
            {
                if (!isSecondDigitBull && playerGuess.FirstDigit == gameNumber.SecondDigit)
                {
                    cows++;
                }
                else if (!isThirdDigitBull && playerGuess.FirstDigit == gameNumber.ThirdDigit)
                {
                    cows++;
                }
                else if (!isFourthDigitBull && playerGuess.FirstDigit == gameNumber.FourthDigit)
                {
                    cows++;
                }
            }

            // checks if playerGuess.SecondDigit is cow:
            if (!isSecondDigitBull)
            {
                if (!isFirstDigitBull && playerGuess.SecondDigit == gameNumber.FirstDigit)
                {
                    cows++;
                }
                else if (!isThirdDigitBull && playerGuess.SecondDigit == gameNumber.ThirdDigit)
                {
                    cows++;
                }
                else if (!isFourthDigitBull && playerGuess.SecondDigit == gameNumber.FourthDigit)
                {
                    cows++;
                }
            }

            // checks if playerGuess.ThirdDigit is cow:
            if (!isThirdDigitBull)
            {
                if (!isFirstDigitBull && playerGuess.ThirdDigit == gameNumber.FirstDigit)
                {
                    cows++;
                }
                else if (!isSecondDigitBull && playerGuess.ThirdDigit == gameNumber.SecondDigit)
                {
                    cows++;
                }
                else if (!isFourthDigitBull && playerGuess.ThirdDigit == gameNumber.FourthDigit)
                {
                    cows++;
                }
            }

            // checks if playerGuess.FourthDigit is cow:
            if (!isFourthDigitBull)
            {
                if (!isFirstDigitBull && playerGuess.FourthDigit == gameNumber.FirstDigit)
                {
                    cows++;
                }
                else if (!isSecondDigitBull && playerGuess.FourthDigit == gameNumber.SecondDigit)
                {
                    cows++;
                }
                else if (!isThirdDigitBull && playerGuess.FourthDigit == gameNumber.ThirdDigit)
                {
                    cows++;
                }
            }

            Result guessResult = new Result(bulls, cows);
            return guessResult;
        }
    }
}
