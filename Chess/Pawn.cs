using System;
using System.Drawing;

namespace Chess
{
    public class Pawn : Figure
    {
        public Pawn( bool isBlack, Point cord) : base("Pawn", isBlack, cord)
        {
        }

        public override string ShortName
        {
            get
            {
                return "P";
            }
        }
        

        public override bool CanMove(Point newCord, Board board)
        {
            if (newCord.X > 7 || newCord.Y > 7 || newCord.X < 0 || newCord.Y < 0) throw new Exception("Кординаты не входять диапозон от 0 до 7");
            int directionColor = -1;
            if (!isBlack)
            {
                directionColor = 1;
            }
            if (newCord.Y == cord.Y + 1 * directionColor && newCord.X == cord.X)
            {
                if (board[newCord] is null) return true;
            }
            else if (newCord.Y == cord.Y + 2 * directionColor && !wasMove && newCord.X == cord.X)
            {
                if (board[newCord] is null) return true;
            }
            else if (newCord.Y == cord.Y + 1 * directionColor && Math.Abs(newCord.X - cord.X) == 1)
            {
                if ((board[newCord] != null) && (board[newCord].IsBlack != this.isBlack)) return true;
            }
            else
            {
                return false;
            }

            return false;
        }

        public override bool CanMove(int x, int y, Board board)
        {
            return CanMove(new Point(x, y), board);
        }
        public override object Clone()
        {
            return new Pawn(isBlack, cord);
        }

        /* public override bool Move(Point newCord, Board board)
         {
             if(CanMove(newCord, board))
             {
                 wasMove = true;

                 //Тут x, y = i, j
                 board[newCord.X, newCord.Y] = this;
                 board[cord] = null;
                 cord = newCord;
                 return true;
             }
             else
             {
                 return false;
             }
         }*/
    }
}