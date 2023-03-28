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
        public char CheckWin(int x, int y, char player)
        {
            int markerCount = 0;
            // check row
            for (int i = 0; i < 3; i++)
            {
                if(_field[x,i] == player)
                {
                    // return n for no
                    markerCount++;

                    if(markerCount == 3)
                    // return y for yes.
                    return 'y';
                }
                else
                {
                    markerCount = 0;
                    break;
                }
            }

            // check column
            for (int i = 0; i < 3; i++)
            {
                if(_field[i,y] == player)
                {
                    // return n for no
                    markerCount++;

                    if(markerCount == 3)
                    // return y for yes.
                    return 'y';
                }
                else
                {
                    markerCount = 0;
                    break;
                }
            }

            // check diagonal
            for (int i = 0; i < 3; i++)
            {
                if(_field[i,i] == player)
                {
                    // return n for no
                    markerCount++;

                    if(markerCount == 3)
                    // return y for yes.
                    return 'y';
                }
                else
                {
                    markerCount = 0;
                    break;
                }
            }

            // check counter-diagonal
            int j = 2;
            for (int i = 0; i < 3 && j >= 0; i++, j--)
            {
                // Counter Diag consits of:
                // [0,2],[1,1],[2,0]
                if(_field[i,j] == player)
                {
                    // return n for no
                    markerCount++;

                    if(markerCount == 3)
                    // return y for yes.
                    return 'y';
                }
                else
                {
                    markerCount = 0;
                    break;
                }
                
            }

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