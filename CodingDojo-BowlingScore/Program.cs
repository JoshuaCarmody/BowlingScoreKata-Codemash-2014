using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo_BowlingScore
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BowlingGame();

            while (!game.IsOver)
            {
                Console.WriteLine("\nYou are on frame {0}, throw {1}. Your score so far is: {2}", game.CurrentFrameNumber, game.CurrentThrow, game.Score);

                int ballsHit;
                string input;

                do
                {
                    Console.WriteLine("You throw the ball. How many balls did you hit?");
                    input = Console.ReadLine();
                }
                while (!Int32.TryParse(input, out ballsHit));

                try
                {
                    game.throwBall(ballsHit);
                    Console.WriteLine("\n");
                    Console.WriteLine(BowlingScoreStringRenderer.Render(game));
                    Console.WriteLine("\n");
                }
                catch (InvalidBowlingFrameException)
                {
                    Console.WriteLine("That isn't possible. Try again");
                }

            }

            Console.WriteLine("Your final score is " + game.Score);
            Console.WriteLine("");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();

        }
    }
}
