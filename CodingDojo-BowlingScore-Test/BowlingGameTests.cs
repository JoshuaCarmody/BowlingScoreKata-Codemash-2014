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

            Assert.AreEqual(300, game.Score);
        }

        [TestMethod]
        public void Rolling_21_5s_Should_Score_150()
        {
            var game = new BowlingGame();

            for (int i = 0; i < 21; i++)
            {
                game.throwBall(5);
            }

            Assert.AreEqual(150, game.Score);
        }

        [TestMethod]
        public void Rolling_A_Strike_Then_18_3s_Should_Score_70()
        {
            var game = new BowlingGame();
            
            game.throwBall(10);
            
            for(int i=0;i<18;i++)
            {
                game.throwBall(3);
            }
            
            Assert.AreEqual((3 * 18) + 16, game.Score);
        }

        [TestMethod]
        public void Rolling_20_Gutter_Balls_Should_Score_0()
        {
            var game = new BowlingGame();

            for (int i = 0; i < 20; i++)
            {
                game.throwBall(0);
            }

            Assert.AreEqual(0, game.Score);
        }

        [TestMethod]
        public void Rolling_20_4s_Should_Score_80()
        {
            var game = new BowlingGame();

            for (int i = 0; i < 20; i++)
            {
                game.throwBall(4);
            }

            Assert.AreEqual(80, game.Score);
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
                    game.throwBall(1);
                }
            }
            catch (BowlingGameOverException e)
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

            Assert.AreEqual(10, game.CurrentFrameNumber);
        }

        [TestMethod]
        public void Spare_On_Tenth_Frame_Should_Allow_Extra_Throw()
        {
            var game = new BowlingGame();

            for (int i = 0; i < 19; i++)
            {
                game.throwBall(4);
            }
            game.throwBall(6);

            Assert.IsFalse(game.IsOver);
            game.throwBall(4);
            Assert.AreEqual((18 * 4) + 14, game.Score);
        }

    }
}
