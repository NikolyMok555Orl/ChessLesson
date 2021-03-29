using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board : ICloneable
    {
        Figure[,] board = new Figure[8, 8];
        bool isBlack = false;
        GameStates gameState;
        public bool IsBlack { get => isBlack;  }
        public GameStates GameState { get => gameState;  }

        public enum GameStates
        {
            gaming, winWhite, winBlack, stalemate, check
        }

        public Board()
        {
            int rows = board.GetUpperBound(0) + 1;
            int columns = board.GetUpperBound(1) + 1;
            gameState = GameStates.gaming;

            for (int i = 0; i < columns; i++)
            {
                this[i, 1] = new Pawn(false, new Point(i, 1));
                this[i, 6] = new Pawn(true, new Point(i, 6));
                if (i == 0 || i == 7)
                {
                    this[i, 0] = new Rook(false, new Point(i, 0));
                    this[i, 7] = new Rook(true, new Point(i, 7));
                }
                if (i == 1 || i == 6)
                {
                    this[i, 0] = new Horse(false, new Point(i, 0));
                    this[i, 7] = new Horse(true, new Point(i, 7));
                }
                if (i == 2 || i==5)
                {
                    this[i, 0] = new Bishop(false, new Point(i, 0));
                    this[i, 7] = new Bishop(true, new Point(i, 7));
                }
            }
            this[4, 0] = new King(false, new Point(4, 0));
            this[4, 7] = new King(true, new Point(4, 7));
            this[3, 0] = new Queen(false, new Point(3, 0));
            this[3, 7] = new Queen(true, new Point(3, 7));


        }
        public Board(bool emptiness)
        {

        }



        public Figure this[int x, int y]
        {
            get
            {
                if (x > -1 && y > -1 && x < 8 && y < 8)
                {
                    return board[y, x];
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }

            set{

                if (x > -1 && y > -1 && x < 8 && y < 8)
                {
                     board[y, x]=value;
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }
        }

        public Figure this[Point point]
        {
            get
            {
                if (point.X > -1 && point.Y > -1 && point.X < 8 && point.Y < 8)
                {
                    return board[ point.Y, point.X];
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }

            set
            {

                if (point.X > -1 && point.Y > -1 && point.X < 8 && point.Y < 8)
                {
                    board[point.Y, point.X] = value;
                }
                else
                {
                    throw new Exception("Индескы не от 0-7");
                }
            }
        }

        public  string ToStringLine(int y)
        {
            string iLine = "";
            for (int x = 0; x < board.GetUpperBound(1) + 1; x++)
            {
                if(this[x, y]!= null){
                    iLine += this[x, y].ShortName+ (this[x, y].IsBlack?"b":"w");
                }
                else
                {
                    iLine += x;
                }
            }
            return iLine;
        }

        public override string ToString()
        {
            string boardLine = "";
            for (int y = 0; y < board.GetUpperBound(0) + 1; y++)
            {
                boardLine +=y+":"+ ToStringLine(y)+";";
            }
            return boardLine;
        }

        public object Clone()
        {
            Board boardNew = new Board(true);
            int rows = this.board.GetUpperBound(0) + 1;
            int columns = this.board.GetUpperBound(1) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (this[i, j] != null) {
                        boardNew[i, j] = (Figure)this[i, j].Clone();
                            }

                }
            }
            return boardNew;
        }
        /// <summary>
        /// Может ли быть побита фигура другого цвета, если да true, иначе false
        /// </summary>
        /// <param name="positionOnChess"></param>
        /// <param name="colorEnemy"></param>
        /// <returns></returns>
        public bool CanBeDamager(Point positionOnChess, bool colorEnemy)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (this[i, j] != null)
                        if (this[i, j].IsBlack != colorEnemy)
                            if (this[i, j].CanMove(positionOnChess, this)) return true;
                }
            return false;
        }


        public bool Move(Point fromCell, Point toCell)
        {
            if (CheckCoordinatesNotNull(fromCell) && this[fromCell].IsBlack==IsBlack) {
                if (this[fromCell].Move(toCell, this))
                {
                    isBlack = isBlack ? false : true;
                    return true;
                }
                else return false;
            }
            else return false;
        }


        public bool Check()
        {
            King kingWhite = FindKing(false);
            King kingBlack = FindKing(true);
            if (CanBeDamager(kingWhite.Cord, kingWhite.IsBlack)) {
                gameState = GameStates.check;
                return true;

            }
            if (CanBeDamager(kingBlack.Cord, kingBlack.IsBlack)) {
                gameState = GameStates.check;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Если шах текущему цвету
        /// </summary>
        /// <param name="isBlack"></param>
        /// <returns></returns>
        public bool Check(bool isBlack)
        {
            King king=FindKing(isBlack);
            if (CanBeDamager(king.Cord, king.IsBlack)) {
                gameState = GameStates.check;
                return true; }
            return false;
        }


        public GameStates Mate()
        {
            if (!Check()) return GameStates.gaming;
            Dictionary<bool, King> kings = new Dictionary<bool, King>();
            kings.Add(false, FindKing(false));
            kings.Add(true, FindKing(true));
            foreach (var king in kings)
            {

            }
            return GameStates.gaming;
        }


        private  bool CheckCoordinatesNotNull(Point point)
        {
            if (point.X >= 0 && point.Y >= 0 && point.X < 8 && point.Y < 8 && this[point] != null) return true;
            else return false;
               
        }


        private King FindKing(bool isBlack)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this[i, j] != null)
                    {
                        if (this[i, j] is King && this[i, j].IsBlack== isBlack)
                            return this[i, j] as King;
                    }
                }
            }
            throw new Exception("На доске не короля "+(isBlack?"черного":"белого"));
        }

    }
}
