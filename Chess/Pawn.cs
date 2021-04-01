using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    public class Pawn : Figure
    {
        new const int CostFigure = 1;
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
            if (!Board.CordIsCorrect(newCord)) return false;
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
                if (!(board[new Point(newCord.X, cord.Y + 1 * directionColor)] is null)) return false;
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<Point> ListCanMove(Board board)
        {
            List<Point> pointsCanMove = new List<Point>();
            int sign = -1;
            if (!IsBlack)
            {
                sign = 1;
            }

            //вперед
            if (CanMove(cord.X, cord.Y + sign, board)) pointsCanMove.Add(new Point(cord.X, cord.Y + sign));
            if (CanMove(cord.X, cord.Y + 2*sign, board)) pointsCanMove.Add(new Point(cord.X, cord.Y + 2 * sign));
            //бить
            if (CanMove(cord.X-1, cord.Y + sign, board)) pointsCanMove.Add(new Point(cord.X - 1, cord.Y + sign));
            if (CanMove(cord.X + 1, cord.Y + sign, board)) pointsCanMove.Add(new Point(cord.X + 1, cord.Y + sign));


            return pointsCanMove;
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