using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{

    public class Rook : Figure
    {
        new const int CostFigure = 5;
        public Rook(bool isBlack, Point cord) : base("Rook", isBlack, cord)
        {
        }

        public override string ShortName
        {
            get
            {
                return "R";
            }
        }

        public override bool CanMove(Point newCord, Board board)
        {
            if (!Board.CordIsCorrect(newCord)) return false;
            if (!((cord.X == newCord.X) || (cord.Y == newCord.Y))) return false;


            //проверка хода по вертикали или горизантали
            int minI, maxI;
            Point direction = new Point(0, 0);
            if (cord.X != newCord.X)
            {
                minI = Math.Min(cord.X, newCord.X);
                maxI = Math.Max(cord.X, newCord.X);
                direction.X = Math.Sign(newCord.X - cord.X);
            }
            else
            {
                minI = Math.Min(cord.Y, newCord.Y);
                maxI = Math.Max(cord.Y, newCord.Y);
                direction.Y = Math.Sign(newCord.Y - cord.Y);
            }

            for (int i = 1; i <= maxI - minI - 1; i++)
            {
                if (board[cord.X + i * direction.X, cord.Y + i * direction.Y] != null)
                    return false;
            }

            if (board[newCord.X, newCord.Y] == null || board[newCord.X, newCord.Y].IsBlack != this.isBlack) return true;
            else return false;
        }

        public override bool CanMove(int x, int y, Board board)
        {
            return CanMove(new Point(x, y), board);
        }

        public override object Clone()
        {
            return new Rook(isBlack, cord);
        }

        public override List<Point> ListCanMove(Board board)
        {
            List<Point> pointsCanMove = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                //по горизонтали и вертикали
                if (cord.X - i > -1 && CanMove(new Point(cord.X - i, cord.Y), board)) pointsCanMove.Add(new Point(cord.X - i, cord.Y));
                if (cord.X + i < 8 && CanMove(new Point(cord.X + i, cord.Y), board)) pointsCanMove.Add(new Point(cord.X + i, cord.Y));
                if (cord.Y - i > -1 && CanMove(new Point(cord.X, cord.Y - i), board)) pointsCanMove.Add(new Point(cord.X, cord.Y - i));
                if (cord.Y + i < 8 && CanMove(new Point(cord.X, cord.Y + i), board)) pointsCanMove.Add(new Point(cord.X, cord.Y + i));
            }

            return pointsCanMove;

        }

        /* public override bool Move(Point newCord, Board board)
         {

         }*/
    }


}
