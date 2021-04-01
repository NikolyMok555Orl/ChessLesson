using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /// <summary>
    /// Слон
    /// </summary>
    public class Bishop : Figure
    {
        new const int CostFigure = 3;
        public Bishop(bool isBlack, Point cord) : base("Bishop ", isBlack, cord)
        {
        }

        public override string ShortName => "B";

        public override bool CanMove(Point newCord, Board board)
        {
            if (!Board.CordIsCorrect(newCord)) return false;
            if (Math.Abs(cord.X-newCord.X) ==Math.Abs(cord.Y - newCord.Y))
            {
                int dirX = Math.Sign(newCord.X - cord.X);
                int dirY = Math.Sign(newCord.Y - cord.Y);
                for (int t = 1; t < Math.Abs(newCord.X - cord.X) ; t++)
                {
                    if (board[cord.X + t * dirX, cord.Y + t * dirY] != null) return false;
                }

                if (board[newCord.X, newCord.Y] == null || board[newCord.X, newCord.Y].IsBlack != isBlack) return true;
            }

            return false;
        }

        public override bool CanMove(int x, int y, Board board)
        {
            return CanMove(new Point(x, y), board);
        }

        public override object Clone()
        {
            return new Bishop(isBlack, cord); 
        }

        public override List<Point> ListCanMove(Board board)
        {
            List<Point> pointsCanMove = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                if (cord.X + i<8 && cord.Y + i<8 && CanMove(new Point(cord.X + i, cord.Y + i), board)) pointsCanMove.Add(new Point(cord.X + i, cord.Y + i));
                if (cord.X - i > -1 && cord.Y - i > -1 && CanMove(new Point(cord.X - i, cord.Y - i), board)) pointsCanMove.Add(new Point(cord.X - i, cord.Y - i));
                if (cord.X + i < 8 && cord.Y - i > -1 && CanMove(new Point(cord.X + i, cord.Y - i), board)) pointsCanMove.Add(new Point(cord.X + i, cord.Y - i));
                if (cord.X - i > -1 && cord.Y + i < 8 && CanMove(new Point(cord.X - i, cord.Y + i), board)) pointsCanMove.Add(new Point(cord.X - i, cord.Y + i));
            }


            return pointsCanMove;
        }
    }
}
