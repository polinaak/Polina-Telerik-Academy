using System;

namespace BullsAndCows
{
    /// <summary>
    /// Prints messages on the console.
    /// </summary>
    public static class Printer
    {
        private const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        private const string WrongNumberMessage = "Wrong number!";
        private const string InvalidCommandMessage = "Incorrect guess or command!";
        private const string NumberGuessedWithoutCheats = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        private const string NumberGuessedWithCheats = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        private const string GoodBuyMessage = "Good bye!";

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine(WelcomeMessage);
        }

        public static void PrintWrongNumberMessage()
        {
            Console.Write(WrongNumberMessage);
        }

        public static void PrintInvalidCommandMessage()
        {
            Console.WriteLine(InvalidCommandMessage);
        }

        public static void PrintNumberGuessedWithoutCheats(byte guessCount)
        {
            Console.Write(NumberGuessedWithoutCheats, guessCount,
                guessCount == 1 ? "attempt" : "attempts");
        }

        public static void PrintNumberGuessedWithCheats(byte guessCount, byte cheatCount)
        {
            Console.WriteLine(NumberGuessedWithCheats,
                guessCount, guessCount == 1 ? "attempt" : "attempts",
                cheatCount, cheatCount == 1 ? "cheat" : "cheats");
        }

        public static void PrintGoodBuyMessage()
        {
            Console.WriteLine(GoodBuyMessage);
        }
    }
}
