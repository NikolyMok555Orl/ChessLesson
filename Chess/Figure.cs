using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Figure : ICloneable
    {
        protected String name;
        protected bool isBlack;
        protected Point cord;
        protected bool wasMove;

        public bool IsBlack { get => isBlack; }
        public string Name { get => name; }
        public Point Cord { get => cord; }
        public bool WasMove { get => wasMove;  }

        protected Figure(string name, bool isBlack, Point cord)
        {
            this.name = name;
            this.isBlack = isBlack;
            this.cord = cord;
            wasMove = false;
        }
         public abstract string ShortName { get; }
            

        public abstract bool CanMove(Point newCord, Board board);
        public abstract bool CanMove(int x, int y, Board board);

        public virtual bool CanMoveNotChech(Point newCord, Board board, bool isBlack)
        {
            return !board.Check(isBlack);
        }
        /// <summary>
        /// Двигает фигуру
        /// </summary>
        /// <param name="newCord">кординаты</param>
        /// <param name="board">доска</param>
        /// <returns>Если ход был, то возращает true</returns>
        public virtual bool Move(Point newCord, Board board)
        {
            if (CanMove(newCord, board) )
            {
                //turn+check for check
                Board newBoard = board.Clone() as Board;
                newBoard[cord.X, cord.Y].MoveWithoutCheck(newCord, newBoard);
                //newBoard[newCord.X, newCord.Y] = this;
                //newBoard[cord] = null;
                if (!CanMoveNotChech(newCord, newBoard, board[cord].isBlack)) {
                    return false;
                }


                wasMove = true;
                //Тут x, y = i, j
                board[newCord.X, newCord.Y] = this;
                board[cord] = null;
                cord = newCord;
                board.Check();
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Move(int x, int y, Board board)
        {
            return Move(new Point(x, y), board);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}-({2},{3})", isBlack ? "Черная " : "Белая ", ShortName, cord.X, cord.Y);
        }

        public virtual void MoveWithoutCheck(Point newPosition, Board board)
        {
            board[newPosition.X, newPosition.Y] = this;
            board[cord.X, cord.Y] = null;
            wasMove = true;
            cord.Y = newPosition.Y;
            cord.X = newPosition.X;
        }

        public abstract object Clone();
        
    }
}
