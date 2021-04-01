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
        new const int CostFigure = 3;
        public Horse(bool isBlack, Point cord) : base("Horse", isBlack, cord)
        {
        }

        public override string ShortName => "H";

        public override bool CanMove(Point newCord, Board board)
        {
            if (!Board.CordIsCorrect(newCord)) return false;
            int madX = Math.Abs(cord.X - newCord.X);
            int madY = Math.Abs(cord.Y - newCord.Y);
            if (((madX == 1) && (madY == 2)) || ((madX == 2) && (madY == 1)))
                if ((board[newCord.X, newCord.Y] == null) || (board[newCord.X, newCord.Y].IsBlack != isBlack)) return true;
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

        public override List<Point> ListCanMove(Board board)
        {
            List<Point> pointsCanMove = new List<Point>();
            for (int i = -2; i < 3; i++)
            {
                Point newPosition = new Point(cord.X+i, cord.Y+2);
                if(CanMove(newPosition, board)) pointsCanMove.Add(newPosition);
                newPosition = new Point(cord.X + i, cord.Y -2);
                if (CanMove(newPosition, board)) pointsCanMove.Add(newPosition);
                newPosition = new Point(cord.X -2, cord.Y - i);
                if (CanMove(newPosition, board)) pointsCanMove.Add(newPosition);
                newPosition = new Point(cord.X + 2, cord.Y - i);
                if (CanMove(newPosition, board)) pointsCanMove.Add(newPosition);
            }
            return pointsCanMove;
        }
    }
}
