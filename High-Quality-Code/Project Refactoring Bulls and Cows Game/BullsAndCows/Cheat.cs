using System;

namespace BullsAndCows
{
    /// <summary>
    /// Reveals bulls to the player.
    /// </summary>
    public class Cheat
    {
        private const byte MaxCheatsAllowed = 4;
        private char[] cheatNumber;
        private byte count;

        public Cheat()
        {
            this.cheatNumber = new char[MaxCheatsAllowed] { 'X', 'X', 'X', 'X' };
            this.count = 0;
        }

        public char[] CheatNumber
        {
            get
            {
                return this.cheatNumber;
            }
            private set
            {
                this.cheatNumber = value;
            }
        }

        public byte Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public string GetCheat(GameNumber theNumber)
        {
            Random randPosGenerator = new Random();

            if (this.count < MaxCheatsAllowed)
            {
                while (true)
                {
                    int randPossition = randPosGenerator.Next(0, 4);
                    if (cheatNumber[randPossition] == 'X')
                    {
                        switch (randPossition)
                        {
                            case 0:
                                this.cheatNumber[randPossition] = (char)(theNumber.FirstDigit + '0');
                                break;
                            case 1:
                                this.cheatNumber[randPossition] = (char)(theNumber.SecondDigit + '0');
                                break;
                            case 2:
                                this.cheatNumber[randPossition] = (char)(theNumber.ThirdDigit + '0');
                                break;
                            case 3:
                                this.cheatNumber[randPossition] = (char)(theNumber.FourthDigit + '0');
                                break;
                        }
                        break;
                    }
                }

                this.count++;
            }

            return new String(cheatNumber);
        }
    }
}