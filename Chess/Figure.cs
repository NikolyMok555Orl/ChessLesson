using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Figure
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

        public abstract bool Move(Point newCord, Board board);

        public override string ToString()
        {
            return string.Format("{0} {1}-({2},{3})", isBlack ? "Черная " : "Белая ", ShortName, cord.X, cord.Y);
        }

    }
}
