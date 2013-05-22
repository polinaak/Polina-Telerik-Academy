using System;
using BullsAndCows;

namespace BullsAndCowsExample
{
    class BullsAndCowsGame
    {
        public const string ScoresFile = "scores.txt";

        static void Main()
        {
            ScoreBoard board = new ScoreBoard(ScoresFile);
            Engine engine = new Engine(board);
            engine.Run();
            board.SaveToFile(ScoresFile);
        }
    }
}
