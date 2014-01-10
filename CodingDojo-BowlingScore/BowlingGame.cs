using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BowlingScore
{
    public class BowlingGame
    {
        protected int gameScore = 0;

        public int Score
        {
            get
            {
                return gameScore;
            }
        }

        public void throwBall(int pinsHit)
        {
            gameScore += pinsHit;
        }
    }
}
