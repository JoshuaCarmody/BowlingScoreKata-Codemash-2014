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
        protected bool gameIsOver = false;

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
        public bool IsOver
        {
            get
            {
                return gameIsOver;
            }
        }

        public void throwBall(int pinsHit)
        {
            // Can't throw balls if the game is over. Duh.
            if (gameIsOver)
            {
                throw new BowlingGameOverException();
            }

            gameFrames[currentFrame - 1].throwBall(pinsHit);

            if (gameFrames[currentFrame - 1].IsOver)
            {
                if (currentFrame == 10)
                {
                    gameIsOver = true;
                }
                else
                {
                    currentFrame++;
                }
            }

            RecalculateScore();
        }

        private void RecalculateScore()
        {
            gameScore = 0;

            for (int i = 0; i < gameFrames.Length; i++)
            {
                List<BowlingFrame> nextFrames = new List<BowlingFrame>();
                if (i < (gameFrames.Length - 1))
                {
                    nextFrames.Add(gameFrames[i + 1]);
                }
                if (i < (gameFrames.Length - 2))
                {
                    nextFrames.Add(gameFrames[i + 2]);
                }
                gameFrames[i].calculateScore(nextFrames);
            }

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
