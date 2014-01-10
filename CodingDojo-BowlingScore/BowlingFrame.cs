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
        protected bool frameScoringCompleted = false;

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

            calculateScore(null);
        }

        public void calculateScore(List<BowlingFrame> nextFrames)
        {
            frameScoringCompleted = false;
            bonusScore = 0;

            // No bonus points this frame if you didn't hit all 10 pins.
            if (!frameIsStrike && !frameIsSpare)
            {
                frameScoringCompleted = true;
                return;
            }

            if (frameNumber < 10)
            {
                if (nextFrames == null)
                {
                    return; // Can't calculate bonus points. The next balls haven't been thrown (or weren't provided).
                }

                var nextRolls = nextFrames.SelectMany(f => f.rolls).ToList();

                if (frameIsSpare && nextRolls.Count >= 1)
                {
                    bonusScore = nextRolls[0];
                    frameScoringCompleted = true;
                }
                else if (frameIsStrike && nextRolls.Count >= 2)
                {
                    bonusScore = nextRolls[0] + nextRolls[1];
                    frameScoringCompleted = true;
                }
            }
            // No bonus points are needed for frame 10, because the roll scores are already included.
        }
    }
}
