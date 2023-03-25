using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TictacToe
{
    public class Game
    {
        private char[,] _field = new char[3,3];
        public char[,] Field
        {
            get => _field;
            set {
                _field = value;
            }
        }
    public void PrintField()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(_field[i,j]);
            }
            Console.WriteLine();
        }
    }
    }

    
}