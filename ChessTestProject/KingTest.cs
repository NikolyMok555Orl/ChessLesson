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
        //проеверка рокировку
        [TestMethod]
        public void RokirovkaTrue()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0] = new Rook(false, new Point(0, 0));
            //board[3, 7].Move(4, 7, board);
            Assert.AreEqual(true, board[4, 0].CanMove(2,0 , board));
        }

        //проеверка рокировку
        [TestMethod]
        public void RokirovkaFalse()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0] = new Rook(false, new Point(0, 0));
            board[4, 0].Move(3, 0, board);
            Assert.AreEqual(false, board[3, 0].CanMove(1, 0, board));
        }

        //проеверка рокировку
        [TestMethod]
        public void RokirovkaMoveTrue()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0] = new Rook(false, new Point(0, 0));
            bool res = board[4, 0].Move(2, 0, board);
            Assert.AreEqual(true, res);
            Assert.AreEqual(true, board[3, 0] is Rook);
        }

        //проеверка рокировку
        [TestMethod]
        public void RokirovkaMoveFalse()
        {
            Board board = new Board(true);
            board[4, 0] = new King(false, new Point(4, 0));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0] = new Rook(false, new Point(0, 0));
            board[4, 0].Move(5, 0, board);
            bool res = board[5, 0].Move(3, 0, board);
            Assert.AreEqual(false, res);
        }

    }
}
