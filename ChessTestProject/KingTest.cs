using System;
using System.Drawing;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTestProject
{
    [TestClass]
    public class KingTest
    {
        [TestMethod]
        public void TestMethodKingOneMove()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            Assert.AreEqual(true, board[4, 0].CanMove(new Point(4, 1), board));

        }


        [TestMethod]
        public void TestMethodKingRokirovka()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[4, 0] = new Rook(false, new Point(0, 0));
            Assert.AreEqual(true, board[4, 0].CanMove(new Point(2, 0), board));
        }

        [TestMethod]
        public void TestMethodKingRokirovkaFalse()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[0, 0] = new Rook(false, new Point(0, 0));
            board[4, 0].Move(3, 0, board);
            Assert.AreEqual(false, board[3, 0].CanMove(new Point(1, 0), board));

        }

        [TestMethod]
        public void CheckKingWhiteTrueTest()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[0, 0] = new King(true, new Point(0, 0));
            board[3, 7] = new Queen(true, new Point(3, 7));
            board[3, 7].Move(4, 7, board);
            Assert.AreEqual(true, board.Check(false));
        }

        [TestMethod]
        public void CheckKingWhiteFalseTest()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[0, 0] = new King(true, new Point(0, 0));
            board[3, 7] = new Queen(true, new Point(3, 7));
            //board[3, 7].Move(4, 7, board);
            Assert.AreEqual(false, board.Check(false));

        }


    }
}
