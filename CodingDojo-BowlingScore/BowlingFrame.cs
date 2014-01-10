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
                return rolls.Sum() + bonusScore;
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
            // You can't throw a ball on an ended frame.
            if(frameIsOver)
            {
                throw new BowlingFrameOverException();
            }

            // You can only knock over a total of 10 pins.
            if (rolls.Sum() + pinsHit > 10)
            {
                throw new InvalidBowlingFrameException();
            }

            rolls[currentRoll] = pinsHit;

            if (currentRoll == 0 && Score == 10)
            {
                frameIsStrike = true;
            }
            else if (currentRoll == 1 && Score == 10)
            {
                frameIsSpare = true;
            }

            // Check for end frames.
            // All frames except the 10th end after 2 rolls.
            if (frameNumber != 10 && currentRoll >= 1)
            {
                frameIsOver = true;
            }
            // Throwing a strike ends the frame, if not the tenth.
            if (frameNumber != 10 && frameIsStrike)
            {
                frameIsOver = true;
            }
            

            if (!frameIsOver)
            {
                currentRoll++;
            }
        }
    }
}
