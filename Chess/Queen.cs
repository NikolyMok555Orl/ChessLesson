using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Queen : Bishop
    {
        public Queen(bool isBlack, Point cord) : base(isBlack, cord)
        {
            this.name = "Queen";
        }

        public override string ShortName => "Q";

        public override bool CanMove(Point newCord, Board board)
        {
            if (base.CanMove(newCord, board))
                return true;
            else
            {
                /*int xyMin = 0;
                int xyMax = 0;
                bool isX = true;*/
                if (!((cord.X == newCord.X) || (cord.Y == newCord.Y))) return false;


                //проверка хода по вертикали или горизантали
                int minI, maxI;
                Point direction = new Point(0,0);
                if (cord.X != newCord.X) {
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

                for(int i = 1; i < maxI - minI-1; i++)
                {
                    if (board[cord.X+i*direction.X, cord.Y + i * direction.Y] != null)
                        return false;
                }

                if (board[newCord.X, newCord.Y] == null || board[newCord.X, newCord.Y].IsBlack != this.isBlack) return true;
                else return false;



                /* if (cord.X != newCord.X)
                 {
                     xyMin = Math.Min(cord.X < newCord.X ? cord.X + 1 : cord.X - 1, newCord.X);
                     xyMax = Math.Max(cord.X < newCord.X ? cord.X + 1 : cord.X - 1, newCord.X);
                 }
                 else if(cord.Y!=newCord.Y)
                 {
                     isX = false;
                     xyMin = Math.Min(cord.Y < newCord.Y ? cord.Y + 1 : cord.Y - 1, newCord.Y);
                     xyMax = Math.Max(cord.Y < newCord.Y ? cord.Y + 1 : cord.Y - 1, newCord.Y);
                 }
                 else
                 {
                     return false;
                 }



                 for (int i = xyMin; i < xyMax && i < 8; i++)
                 {
                     if (isX)
                     {
                         if (board[i, cord.Y] != null) return false;
                     }
                     else
                     {
                         if (board[cord.X, i] != null) return false;
                     }
                 }
                 if (isX)
                 {
                     if (board[newCord.X, cord.Y] == null || board[newCord.X, cord.Y].IsBlack != this.isBlack) return true;
                     else return false;
                 }
                 else
                 {
                     if (board[cord.X, newCord.Y] == null || board[cord.X, newCord.Y].IsBlack != this.isBlack) return true;
                     else return false;
                 }*/
            }

        }

        public override bool CanMove(int x, int y, Board board)
        {
            return CanMove(new Point(x, y), board);
        }

        /*public override bool CanMoveNotChech(Point newCord, Board board, bool isBlack)
        {
            return base.CanMoveNotChech(newCord, board, isBlack);
        }*/

        public override object Clone()
        {
            return new Queen(isBlack, cord);
        }

       /* public override void MoveWithoutCheck(Point newPosition, Board board)
        {
            base.MoveWithoutCheck(newPosition, board);
        }*/

        
    }
}
