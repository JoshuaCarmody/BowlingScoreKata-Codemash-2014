using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BowlingScore
{
    public class BowlingGame
    {
        BowlingFrame[] gameFrames;

        protected int gameScore = 0;
        protected int currentFrame = 1;

        public int Score
        {
            get
            {
                return gameScore;
            }
        }

        public int Frame
        {
            get
            {
                return currentFrame;
            }
        }

        public void throwBall(int pinsHit)
        {
            gameFrames[currentFrame - 1].throwBall(pinsHit);

            if (gameFrames[currentFrame - 1].IsOver)
            {
                currentFrame++;
            }

            RecalculateScore();
        }

        private void RecalculateScore()
        {
            gameScore = 0;
            foreach (var frame in gameFrames)
            {
                gameScore += frame.Score;
            }
        }

        public BowlingGame()
        {
            gameFrames = new BowlingFrame[10];
            for (int i = 0; i < 10; i++)
            {
                gameFrames[i] = new BowlingFrame(i + 1); // Bowling frame numbers are 1-based, array index is 0-based
            }
        }
    }
}
