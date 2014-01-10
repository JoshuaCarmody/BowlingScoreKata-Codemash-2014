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
            gameScore += pinsHit;
        }

        public BowlingGame()
        {
            gameFrames = new BowlingFrame[10];
            for (int i = 0; i < 10; i++)
            {
                gameFrames[i] = new BowlingFrame();
            }
        }
    }
}
