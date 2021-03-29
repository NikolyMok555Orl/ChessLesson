using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Bishop : Figure
    {
        public Bishop(bool isBlack, Point cord) : base("Bishop ", isBlack, cord)
        {
        }

        public override string ShortName => "B";

        public override bool CanMove(Point newCord, Board board)
        {
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
    }
}
