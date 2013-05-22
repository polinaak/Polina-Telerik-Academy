using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BullsAndCows
{
    /// <summary>
    /// Writes and reads player scores from file.
    /// </summary>
    public class ScoreBoard
    {
        private readonly SortedSet<PlayerScore> scores;
        private const int MaxPlayersToShowInScoreboard = 10;

        public ScoreBoard(string filename)
        {
            this.scores = new SortedSet<PlayerScore>();
            try
            {
                using (StreamReader inputStream = new StreamReader(filename))
                {
                    while (!inputStream.EndOfStream)
                    {
                        string scoreString = inputStream.ReadLine();
                        this.scores.Add(PlayerScore.Deserialize(scoreString));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddScore(string name, int guesses)
        {
            PlayerScore newScore = new PlayerScore(name, guesses);
            this.scores.Add(newScore);
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter outputStream = new StreamWriter(filename))
                {
                    foreach (PlayerScore playerScore in scores)
                    {
                        outputStream.WriteLine(playerScore.Serialize());
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            if (scores.Count == 0)
            {
                return "Top scoreboard is empty." + Environment.NewLine;
            }

            StringBuilder scoreBoard = new StringBuilder();
            scoreBoard.AppendLine("Scoreboard:");
            int count = 0;

            foreach (PlayerScore playerScore in scores)
            {
                count++;
                scoreBoard.AppendLine(string.Format("{0}. {1}", count, playerScore));
                if (count > MaxPlayersToShowInScoreboard)
                {
                    break;
                }
            }

            return scoreBoard.ToString();
        }
    }
}
