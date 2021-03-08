using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board
    {
        Figure[,] board = new Figure[8, 8];

        public Board()
        {
            int rows = board.GetUpperBound(0) + 1;
            int columns = board.GetUpperBound(1) + 1;

            for (int i = 0; i < columns; i++)
            {
                this[i, 1] = new Pawn(false, new Point(i, 1));
                this[i, 6] = new Pawn(true, new Point(i, 6));
            }

        }

        public Figure this[int x, int y]
        {
            get
            {
                if (x > -1 && y > -1 && x < 8 && y < 8)
                {
                    return board[y, x];
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }

            set{

                if (x > -1 && y > -1 && x < 8 && y < 8)
                {
                     board[y, x]=value;
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }
        }

        public Figure this[Point point]
        {
            get
            {
                if (point.X > -1 && point.Y > -1 && point.X < 8 && point.Y < 8)
                {
                    return board[ point.Y, point.X];
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }

            set
            {

                if (point.X > -1 && point.Y > -1 && point.X < 8 && point.Y < 8)
                {
                    board[point.Y, point.X] = value;
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }
        }

        public  string ToStringLine(int y)
        {
            string iLine = "";
            for (int x = 0; x < board.GetUpperBound(1) + 1; x++)
            {
                if(this[x, y]!= null){
                    iLine += this[x, y].ShortName+ (this[x, y].IsBlack?"b":"w");
                }
                else
                {
                    iLine += x;
                }
            }
            return iLine;
        }

        public override string ToString()
        {
            string boardLine = "";
            for (int y = 0; y < board.GetUpperBound(0) + 1; y++)
            {
                boardLine +=y+":"+ ToStringLine(y)+";";
            }
            return boardLine;
        }
    }
}
