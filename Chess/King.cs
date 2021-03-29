using System;
using System.Drawing;

namespace Chess
{
    public class King : Figure
    {
        public override string ShortName => "K";

        public King(bool isBlack, Point cord) : base("King", isBlack, cord)
        {
        }

        public override bool CanMove(Point newPosition, Board board)
        {
            int madX = Math.Abs(cord.X - newPosition.X);
            int madY = Math.Abs(cord.Y - newPosition.Y);

            if (Math.Max(madX, madY) == 1)
            {
                if ((board[newPosition.X, newPosition.Y] == null) || (board[newPosition.X, newPosition.Y].IsBlack != isBlack))
                {
                    Board boardNew = (Board)board.Clone();
                    boardNew[cord.X, cord.Y].MoveWithoutCheck(newPosition, boardNew);

                    if (!boardNew.CanBeDamager(newPosition, !isBlack))

                        return true;
                }
            }
            else//ракировка
            {
                if (Rakirovka(newPosition, board)) return true;
            }
            return false;
        }

        public override void MoveWithoutCheck(Point newPosition, Board board)
        {
            board[newPosition.X, newPosition.Y] = this;
            board[cord.X, cord.Y] = null;
            wasMove = true;
            cord.Y = newPosition.Y;
            cord.X = newPosition.X;

            if (Rakirovka(newPosition, board))
            {
                int indexL;
                if (newPosition.X < cord.X) indexL = 0;
                else indexL = 7;

                Point tourPosition;
                //пустые ячейки до короля
                if (indexL == 0)
                    tourPosition = new Point(newPosition.X - 1, newPosition.Y);
                else
                    tourPosition = new Point(newPosition.X + 1, newPosition.Y);
                Figure possibleTour = board[newPosition.X, indexL];
                possibleTour.MoveWithoutCheck(tourPosition, board);
            }
        }

        private bool Rakirovka(Point newPosition, Board board)
        {
            int madX = Math.Abs(cord.X - newPosition.X);
            int madY = Math.Abs(cord.Y - newPosition.Y);
            int indexL;
            if (!((madX == 2) && (madY == 0))) //сдвиг только по горизонтали на 2 ячейки
                return false;
            if (wasMove) //не двигался до этого
                return false;

            //выбор ладьи
            if (newPosition.X < cord.X) indexL = 0;
            else indexL = 7;
            Figure possibleTour = board[newPosition.X, indexL];
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
            if (indexL == 0)
                tourPosition = new Point(newPosition.X - 1, newPosition.Y);
            else
                tourPosition = new Point(newPosition.X + 1, newPosition.Y);
            rez = possibleTour.CanMove(tourPosition, board);
            if (!rez)
                return false;
            //после ракировки не под боем
            Board b = (Board)board.Clone();
            b[cord.X, cord.Y].MoveWithoutCheck(newPosition, board);
            b[newPosition.X, indexL].MoveWithoutCheck(tourPosition, board);

            if (b.CanBeDamager(newPosition, !isBlack))
                return false;
            else
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
    }
}