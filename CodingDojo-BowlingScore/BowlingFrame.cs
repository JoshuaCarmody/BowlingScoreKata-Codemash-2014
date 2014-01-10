using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BowlingScore
{
    public class BowlingFrame
    {
        protected int[] rolls;
        protected int currentRoll = 0;
        protected int frameScore = 0;
        protected int bonusScore = 0;
        protected int frameNumber;
        protected bool frameIsSpare = false;
        protected bool frameIsStrike = false;
        protected bool frameIsOver = false;

        public bool IsSpare
        {
            get
            {
                return frameIsSpare;
            }
        }
        public bool IsStrike
        {
            get
            {
                return frameIsStrike;
            }
        }
        public bool IsOver
        {
            get
            {
                return frameIsOver;
            }
        }
        public int Number
        {
            get
            {
                return frameNumber;
            }
        }
        public int Score
        {
            get
            {
                return frameScore;
            }
        }

        public BowlingFrame(int newFrameNumber)
        {
            frameNumber = newFrameNumber;
            rolls = new int[3];
            for (int i = 0; i < 3; i++)
            {
                rolls[i] = 0;
            }
        }

        public void throwBall(int pinsHit)
        {
            // You can only knock over a total of 10 pins.
            if (rolls.Sum() + pinsHit > 10)
            {
                throw new InvalidBowlingFrameException();
            }

            rolls[currentRoll] = pinsHit;
            currentRoll++;
        }
    }
}
