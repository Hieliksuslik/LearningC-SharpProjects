using System;

namespace DiceGame;
class Program
{
    public static int RollDice()
    {
        return new Random().Next() % 6 + 1;
    }
    static void Main(string[] args)
    {

        int playerRoll;
        int opponentRoll;
        int playerScore = 0;
        int opponentScore = 0;

        bool playAgain = true;


        Console.WriteLine("Welcome to the dice game!");
        Console.WriteLine("Your goal is to hopefully roll higher than your opponent!");
        Console.WriteLine("A higher roll nets you a point, good luck!");

        while (playAgain)
        {
            Console.WriteLine("\nPress any key to roll...");
            Console.ReadKey();

            playerRoll = RollDice();
            opponentRoll = RollDice();

            Console.WriteLine($"\nYour Roll: {playerRoll}");

            if(playerRoll > opponentRoll)
            {
                Console.WriteLine($"\nYou beat the opponents roll of {opponentRoll}!");
                playerScore++;
                Console.WriteLine($"Your score is now: {playerScore}");
            }
            else if (playerRoll < opponentRoll)
            {
                Console.WriteLine($"\nYou lost to the opponents roll of {opponentRoll}!");
                opponentScore++;
                Console.WriteLine($"\nOpponent's score is now: {opponentScore}");
            }
            else
            {
                Console.WriteLine("\nA tie! No points awarded");
            }

            Console.WriteLine("Play again? y for yes, n for no");
            string? result = Console.ReadLine();

            if(result == "y")
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Final results: ");
        Console.WriteLine($"Your final score: {playerScore}, Opponents final score: {opponentScore}");
    }
}