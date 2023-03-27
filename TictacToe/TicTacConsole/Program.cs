using TictacToe;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            char player = 'X';
            int x, y;

            bool gameOver = false;

            char[,] field = new char[3,3] {
                {'.','.','.'},
                {'.','.','.'},
                {'.','.','.'}
            };

            Game game = new Game();
            game.Field = field;

            game.PrintField();

            do
            {

                // TODO: Convert to Try.Parse()
                Console.WriteLine($"\nCurrent Player: {player}\n");

                Console.WriteLine("Type the x-coordinate of your mark: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type the y-coordinate of your mark: ");
                y = Convert.ToInt32(Console.ReadLine());

                // check if valid move
                if(!game.PlaceMarker(x, y, player)){
                    Console.WriteLine("Invalid move, please enter a valid x, y.");
                    continue;
                }

                game.PrintField();

                // Check for Draw
                if(game.CheckDraw())
                {
                    gameOver = true;
                    Console.WriteLine("\n\nDRAW! Neither player wins. Thank you for playing.\n\n");
                }
                // Check if there is a winning move
                // Adjust
                if(game.CheckWin() == 'n')
                {
                    // Not game over, Change current player
                    if(player == 'X')
                        player = 'O';
                    else
                        player = 'X';
                }
                else //Game over!
                {
                    gameOver = true;

                }

                


            } while (!gameOver);
        }
    }
}