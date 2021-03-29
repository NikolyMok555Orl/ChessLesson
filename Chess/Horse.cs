using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Horse : Figure
    {
        public Horse(bool isBlack, Point cord) : base("Horse", isBlack, cord)
        {
        }

        public override string ShortName => "H";

        public override bool CanMove(Point newPosition, Board board)
        {
            int madX = Math.Abs(cord.X - newPosition.X);
            int madY = Math.Abs(cord.Y - newPosition.Y);
            if (((madX == 1) && (madY == 2)) || ((madX == 2) && (madY == 1)))
                if ((board[newPosition.X, newPosition.Y] == null) || (board[newPosition.X, newPosition.Y].IsBlack != isBlack)) return true;
            return false;
        }

        public override bool CanMove(int x, int y, Board board)
        {
            return CanMove(new Point(x, y), board);
        }

        public override object Clone()
        {
            return new Horse(isBlack, cord);
        }


    }
}
