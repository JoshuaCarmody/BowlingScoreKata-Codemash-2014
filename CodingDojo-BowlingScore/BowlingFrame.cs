using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BowlingScore
{
    public class BowlingFrame
    {
        protected List<int> rolls = new List<int>();
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
        public List<int> Rolls
        {
            get
            {
                // TODO: Even though this is a read-only property, could it potentially be modified after being returned? How do I prevent this?
                return rolls;
            }
        }

        public BowlingFrame(int newFrameNumber)
        {
            frameNumber = newFrameNumber;
        }

        public void throwBall(int pinsHit)
        {
            // You can't throw a ball on an ended frame.
            if(frameIsOver)
            {
                throw new BowlingFrameOverException();
            }

            // You can only knock over a total of 10 pins on the first 9 frames.
            if (rolls.Sum() + pinsHit > 10 && frameNumber != 10)
            {
                throw new InvalidBowlingFrameException();
            }
            // You could potentially knock over up to 30 pins on the 10th frame.
            if (rolls.Sum() + pinsHit > 30 && frameNumber == 10)
            {
                throw new InvalidBowlingFrameException();
            }

            rolls.Add(pinsHit);

            if (rolls.Count == 1 && Score == 10)
            {
                frameIsStrike = true;
            }
            else if (rolls.Count == 2 && Score == 10)
            {
                frameIsSpare = true;
            }

            // Check for end frames.
            // All frames except the 10th end after 2 rolls.
            if (frameNumber != 10 && rolls.Count >= 2)
            {
                frameIsOver = true;
            }
            // Throwing a strike ends the frame, if not the tenth.
            else if (frameNumber != 10 && frameIsStrike)
            {
                frameIsOver = true;
            }
            // If you didn't throw a strike in the 10th frame, you only get 2 throws.
            else if (frameNumber == 10 && rolls.Count >= 2 && !frameIsSpare && !frameIsStrike)
            {
                frameIsOver = true;
            }
            // If you threw a strike or a spare in the 10th frame, then the frame ends after 3 balls.
            else if (frameNumber == 10 && rolls.Count >= 3)
            {
                frameIsOver = true;
            }
        }

        public void calculateBonusScore(BowlingFrame[] nextFrames)
        {
            if (frameNumber < 10)
            {

            }
        }
    }
}
