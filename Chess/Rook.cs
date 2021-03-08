using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Figure
    {
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
            int xyMin = 0;
            int xyMax = 0;
            bool isX = true;

            if (cord.X != newCord.X) {
                xyMin = cord.X + 1;
                xyMax = newCord.X - 1;
            }
            else
            {
                isX = false;
                xyMin = cord.Y + 1;
                xyMax = newCord.Y - 1;
            }


            for (int i = xyMin; i < xyMax; i++)
            {
                if (isX)
                {
                    if (board[i, cord.Y] !=null) return false;
                }
                else
                {
                    if (board[cord.X, i] != null) return false;
                }
            }
        }

        public override bool Move(Point point, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
