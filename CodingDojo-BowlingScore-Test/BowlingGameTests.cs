using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CodingDojo_BowlingScore;

namespace CodingDojo_BowlingScore_Test
{
    [TestClass]
    public class BowlingGameTests
    {
        [TestMethod]
        public void Rolling_12_Strikes_Should_Score_300()
        {
            var game = new BowlingGame();

            for (int i = 0; i < 12; i++)
            {
                game.throwBall(10);
            }

            Assert.AreEqual(game.Score, 300);
        }

        [TestMethod]
        public void Rolling_20_Gutter_Balls_Should_Score_0()
        {
            var game = new BowlingGame();

            for (int i = 0; i < 20; i++)
            {
                game.throwBall(0);
            }

            Assert.AreEqual(game.Score, 0);
        }

        [TestMethod]
        public void Rolling_20_4s_Should_Score_80()
        {
            var game = new BowlingGame();

            for (int i = 0; i < 20; i++)
            {
                game.throwBall(4);
            }

            Assert.AreEqual(game.Score, 80);
        }
        
        [TestMethod]
        public void Rolling_22_Balls_Should_Be_Illegal()
        {
            var game = new BowlingGame();
            bool threwAnError = false;

            try
            {
                for (int i = 0; i < 22; i++)
                {
                    game.throwBall(9);
                }
            }
            catch (BowlingGameAlreadyOverException e)
            {
                threwAnError = true;
            }

            Assert.IsTrue(threwAnError);
        }

        [TestMethod]
        public void Rolling_18_3s_Should_Advance_To_Tenth_Frame()
        {
            var game = new BowlingGame();
            
            for(int i=0;i<18;i++)
            {
                game.throwBall(3);
            }

            Assert.AreEqual(10, game.Frame);
        }

    }
}
