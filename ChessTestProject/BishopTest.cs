using System;
using System.Drawing;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTestProject
{
    [TestClass]
    public class BishopTest
    {
        [TestMethod]
        public void CanMoveFreeBoardWhite()
        {
            Board board = new Board(true);
            board[2, 0] = new Bishop(false, new Point(2, 0));
            Assert.AreEqual(true, board[2, 0].CanMove(new Point(3, 1), board));
        }


        [TestMethod]
        public void CanMoveFreeBoardBlack()
        {
            Board board = new Board(true);
            board[2, 7] = new Bishop(false, new Point(2, 7));
            Assert.AreEqual(true, board[2, 7].CanMove(new Point(3, 6), board));
        }


        [TestMethod]
        public void CanMovePawnBoardWhite()
        {
            Board board = new Board(true);
            board[2, 0] = new Bishop(false, new Point(2, 0));
            Assert.AreEqual(true, board[2, 0].CanMove(new Point(3, 1), board));
        }
    }
}
