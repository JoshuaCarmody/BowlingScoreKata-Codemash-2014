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
                Console.WriteLine("\nYou are on frame " + game.Frame + ", your score so far is: " + game.Score);

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
