using TictacToe;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Game game = new Game();
            char[,] field = new char[3,3] {
                {'.','.','.'},
                {'.','.','.'},
                {'.','.','.'}
            };

            game.Field = field;

            game.PrintField();
        }
    }
}