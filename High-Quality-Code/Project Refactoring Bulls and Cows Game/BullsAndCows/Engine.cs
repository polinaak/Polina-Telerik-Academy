using System;

namespace BullsAndCows
{
    /// <summary>
    /// Executes the game.
    /// </summary>
    public class Engine
    {
        private GameNumber theNumber;
        private PlayerGuess playerGuess;
        private Cheat cheats;
        private readonly ScoreBoard scoreBoard;
        private byte guessCount;

        public Engine(ScoreBoard board)
        {
            this.scoreBoard = board;
            this.guessCount = 0;
            this.cheats = new Cheat();
            this.theNumber = new GameNumber();
        }

        /// <summary>
        /// Starts the game engine.
        /// </summary>
        public void Run()
        {
            Printer.PrintWelcomeMessage();

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    Printer.PrintGoodBuyMessage();
                    break;
                }
                switch (command)
                {
                    case "top":
                        {
                            Console.Write(scoreBoard);
                            break;
                        }
                    case "restart":
                        {
                            Console.WriteLine();
                            ResetGameData();
                            break;
                        }
                    case "help":
                        {
                            Console.WriteLine("The number looks like {0}.", cheats.GetCheat(theNumber));
                            break;
                        }
                    default:
                        {
                            try
                            {
                                PlayerGuessExecutor(command);
                            }
                            catch (ArgumentException)
                            {
                                Printer.PrintInvalidCommandMessage();
                            }
                            break;
                        }
                }
            }
        }

        private void PlayerGuessExecutor(string command)
        {
            playerGuess = PlayerGuess.TryToParse(command);
            Result guessResult = GuessChecker.GetBullsAndCowsMatches(
                playerGuess, theNumber);
            this.guessCount++;

            if (guessResult.Bulls == 4)
            {
                if (this.cheats.Count == 0)
                {
                    Printer.PrintNumberGuessedWithoutCheats(this.guessCount);
                    string name = Console.ReadLine();
                    scoreBoard.AddScore(name, this.guessCount);
                }
                else
                {
                    Printer.PrintNumberGuessedWithCheats(
                        this.guessCount, this.cheats.Count);
                }
                Console.Write(scoreBoard);
                ResetGameData();
            }
            else
            {
                Printer.PrintWrongNumberMessage();
                Console.WriteLine(" {0}", guessResult);
            }
        }

        private void ResetGameData()
        {
            Console.WriteLine();
            Printer.PrintWelcomeMessage();
            this.theNumber = new GameNumber();
            this.cheats = new Cheat();
            this.guessCount = 0;
        }
    }
}
