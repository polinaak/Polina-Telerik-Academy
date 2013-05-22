using System;

namespace BullsAndCows
{
    /// <summary>
    /// Represents player guess result.
    /// </summary>
    public class Result
    {
        private const int MinCount = 0;
        private const int MaxCount = 4;
        private int bulls;
        private int cows;

        public Result(int bulls, int cows)
        {
            this.Bulls = bulls;
            this.Cows = cows;

            if (IsTotalCorrect(bulls, cows))
            {
                throw new ArgumentOutOfRangeException(string.Format(
                        "Total number of bulls and cows must be between {0} and {1}!",
                        MinCount, MaxCount));
            }
        }

        public int Bulls
        {
            get
            {
                return this.bulls;
            }
            set
            {
                if (value < MinCount || MaxCount < value)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                        "The number of bulls must be between {0} and {1}!",
                        MinCount, MaxCount));
                }

                this.bulls = value;
            }
        }

        public int Cows
        {
            get
            {
                return this.cows;
            }
            set
            {
                if (value < MinCount || MaxCount < value)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                        "The number of cows must be between {0} and {1}!",
                        MinCount, MaxCount));
                }

                this.cows = value;
            }
        }

        private bool IsTotalCorrect(int bulls, int cows)
        {
            int totalCattle = bulls + cows;
            if (totalCattle < MinCount || MaxCount < totalCattle)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return string.Format("Bulls: {0}, Cows: {1}", this.Bulls, this.Cows);
        }
    }
}
