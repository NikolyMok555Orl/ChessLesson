using System;
using System.Drawing;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTestProject
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void CheckTrueMethod1()
        {
            Board board = new Board(true);
            board[0, 0] = new King(false, new Point(0, 0));
            board[1, 2] = new Rook(true, new Point(1, 2));
            board[1, 2].Move(new Point(1, 0), board);
            bool f = board.Check();
            Assert.AreEqual(true, f);

        }
    }
}
