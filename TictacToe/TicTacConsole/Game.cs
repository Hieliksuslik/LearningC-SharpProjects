using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TictacToe
{
    public class Game
    {
        private char[,] _field = new char[3,3];

        private int _moveCount = 0;
        public char[,] Field
        {
            get => _field;
            set {
                _field = value;
            }
        }
        public void PrintField()
        {
            Console.WriteLine();
            Console.WriteLine(" 012");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_field[i,j]);
                }
                Console.WriteLine();
            }
        }

        public bool PlaceMarker(int x, int y, char player)
        {
            // If out of bounds, invalid move
            if( x < 0 || x > 2 || y < 0 || y > 2) 
                return false;
            // If not a free space, invalid move
            if(_field[x,y] != '.')
                return false;
             
            _field[x,y] = player;
            _moveCount++;
            return true;
        }
        // CheckWin returns true if there is a win condition.
        // TODO: Re-think how to handle win/draw checks
        public char CheckWin()
        {
            return 'n';
        }

        public bool CheckDraw()
        {
            if(_moveCount == 9)
                return true;
            else
                return false;
        }
    }

}