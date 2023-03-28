using TictacToe;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            char player = 'X';
            char result = ' ';
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
                result = game.CheckWin(x, y, player);

                if(!(result == 'n'))
                {
                    Console.WriteLine($"GAME OVER! Player: {player} has won!");
                    gameOver = true;
                    continue;
                }
                // Check for Draw
                if(!game.CheckDraw())
                {

                    // Not game over, Change current player
                    if(player == 'X')
                        player = 'O';
                    else
                        player = 'X';
                }
                else
                {
                    // Draw!
                    gameOver = true;
                    Console.WriteLine("\n\nDRAW! Neither player wins. Thank you for playing.\n\n");
                }
            } while (!gameOver);
        }
    }
}