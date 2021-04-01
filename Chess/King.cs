using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    public class King : Figure
    {
        new const int CostFigure = 100;
        public override string ShortName => "K";

        public King(bool isBlack, Point cord) : base("King", isBlack, cord)
        {
        }

        public override bool CanMove(Point newCord, Board board)
        {
            if (!Board.CordIsCorrect(newCord)) return false;
            int madX = Math.Abs(cord.X - newCord.X);
            int madY = Math.Abs(cord.Y - newCord.Y);

            if (Math.Max(madX, madY) == 1)
            {
                if ((board[newCord.X, newCord.Y] == null) || (board[newCord.X, newCord.Y].IsBlack != isBlack))
                {
                    Board boardNew = (Board)board.Clone();
                    boardNew[cord.X, cord.Y].MoveWithoutCheck(newCord, boardNew);

                    if (!boardNew.CanBeDamager(newCord, !isBlack))

                        return true;
                }
            }
            else//ракировка
            {
                if (Rakirovka(newCord, board)) return true;
            }
            return false;
        }

        public override void MoveWithoutCheck(Point newPosition, Board board)
        {

            

            if (Rakirovka(newPosition, board))
            {
                int indexL;
                if (newPosition.X < cord.X) indexL = 0;
                else indexL = 7;

                Point tourPosition;
                //пустые ячейки до короля
                if (indexL == 0)
                    tourPosition = new Point(newPosition.X + 1, newPosition.Y);
                else
                    tourPosition = new Point(newPosition.X - 1, newPosition.Y);
                Figure possibleTour = board[indexL, newPosition.Y];
                possibleTour.MoveWithoutCheck(tourPosition, board);
            }
            board[newPosition.X, newPosition.Y] = this;
            board[cord.X, cord.Y] = null;
            wasMove = true;
            cord.Y = newPosition.Y;
            cord.X = newPosition.X;
        }

        private bool Rakirovka(Point newCord, Board board)
        {
            if (!Board.CordIsCorrect(newCord)) return false;
            int madX = Math.Abs(cord.X - newCord.X);
            int madY = Math.Abs(cord.Y - newCord.Y);
            int indexXL;
            int indexYL;
            if (!((madX == 2) && (madY == 0))) //сдвиг только по горизонтали на 2 ячейки
                return false;
            if (wasMove) //не двигался до этого
                return false;

            //выбор ладьи
            if (newCord.X < cord.X) indexXL = 0;
            else indexXL = 7;
            if (!isBlack) indexYL = 0;
            else indexYL = 7;
            Figure possibleTour = board[indexXL, indexYL];
            //должна быть не пустой ячейка с потенциальной турой
            if (possibleTour == null)
                return false;
            //должна быть тура
            if (!(possibleTour is Rook))
                return false;
            //тура не двигалась
            if (possibleTour.WasMove)
                return false;
            bool rez;
            Point tourPosition;
            //пустые ячейки до короля
            if (indexXL == 0)
                tourPosition = new Point(newCord.X + 1, newCord.Y);
            else
                tourPosition = new Point(newCord.X - 1, newCord.Y);
            rez = possibleTour.CanMove(tourPosition, board);
            if (!rez)
                return false;
            //после ракировки не под боем
            /* Board b = (Board)board.Clone();
             b[cord.X, cord.Y].MoveWithoutCheck(newCord, b);
             b[newCord.X, indexXL].MoveWithoutCheck(tourPosition, b);

             if (b.CanBeDamager(newCord, !isBlack))
                 return false;
             else*/
            return true;
        }

        public override bool CanMove(int x, int y, Board board)
        {
            return CanMove(new Point(x, y), board);
        }

        public override object Clone()
        {
            return new King(isBlack, cord);
        }

        public override List<Point> ListCanMove(Board board)
        {
            List<Point> pointsCanMove = new List<Point>();
            for (int i = -1; i < 2; i++)
            {
                if (CanMove(new Point(cord.X + i, cord.Y+1), board)) pointsCanMove.Add(new Point(cord.X - i, cord.Y + 1));
                if (CanMove(new Point(cord.X + i, cord.Y - 1), board)) pointsCanMove.Add(new Point(cord.X + i, cord.Y - 11));
                if (CanMove(new Point(cord.X + i, cord.Y), board)) pointsCanMove.Add(new Point(cord.X + i, cord.Y));
            }
            if (!wasMove)
            {
                if (CanMove(new Point(cord.X + 2, cord.Y), board)) pointsCanMove.Add(new Point(cord.X + 2, cord.Y));
                if (CanMove(new Point(cord.X - 2, cord.Y), board)) pointsCanMove.Add(new Point(cord.X - 2, cord.Y));
            }
            return pointsCanMove;

        }
    }
}