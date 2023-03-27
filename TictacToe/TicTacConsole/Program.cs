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

            } while (!gameOver);
        }
    }
}