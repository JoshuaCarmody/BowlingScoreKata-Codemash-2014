using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BowlingScore
{
    public class BowlingFrame
    {
        int[] rolls;
        int currentRoll = 0;

        public BowlingFrame()
        {
            rolls = new int[3];
            for (int i = 0; i < 3; i++)
            {
                rolls[i] = 0;
            }
        }
    }
}
