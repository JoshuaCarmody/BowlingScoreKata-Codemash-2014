﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BowlingScore
{
    public class BowlingScoreStringRenderer
    {
        protected static char RenderThrowScore(BowlingFrame frame, int throwNumber)
        {
            if (frame.Rolls.Count < throwNumber)
            {
                return '-';
            }
            if(frame.Rolls[throwNumber - 1] == 10 && (frame.Number == 10 || throwNumber == 1))
            {
                return 'X';
            }
            if (throwNumber == 2 && frame.IsSpare)
            {
                return '/';
            }
            return Convert.ToChar(frame.Rolls[throwNumber - 1].ToString());
        }

        public static string Render(BowlingGame game)
        {
            StringBuilder returnString = new StringBuilder();

            // Render headers
            for (int i = 0; i < game.Frames.Count(); i++)
            {
                returnString.AppendFormat("     {0,2:##}", i + 1);
            }
            returnString.AppendLine("\n" + new String('-', game.Frames.Count() * 7));

            // Render individual frame results
            foreach(var frame in game.Frames)
            {
                string frameNumber = String.Format("    {0} {1}", RenderThrowScore(frame, 1), RenderThrowScore(frame, 2));
                returnString.Append(frameNumber);
            }
            returnString.AppendLine("");

            // Render cumulative score
            int cumulativeScore = 0;
            foreach (var frame in game.Frames)
            {
                cumulativeScore += frame.Score;
                if (frame.IsOver && frame.IsScoringCompleted)
                {
                    returnString.AppendFormat("    {0,3:###}", cumulativeScore);
                }
                else
                {
                    returnString.Append(new String(' ', 7));
                }
            }

            return returnString.ToString();
        }
    }
}
