using System;
using System.Drawing;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTestProject
{
    [TestClass]
    public class RookUnitTest
    {
        //"01234567"
        //тест на проходку
        [TestMethod]
        public void MoveWhiteOneRookMethod()
        {
            Board board = new Board();
            board[7, 7] = new King(false, new Point(7, 7));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 1].Move(new Point(0, 2), board);
            board[0, 0].Move(new Point(0, 1), board);


            Assert.AreEqual("RwPwPwPwPwPwPwPw", board.ToStringLine(1));
        }

        [TestMethod]
        public void MoveBlackOneRookMethod()
        {
            Board board = new Board();
            board[7, 7] = new King(false, new Point(7, 7));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 6].Move(new Point(0, 5), board);
            board[0, 7].Move(new Point(0, 6), board);
            Assert.AreEqual("RbPbPbPbPbPbPbPb", board.ToStringLine(6));
        }

        [TestMethod]
        public void MoveWhiteUpRookMethod()
        {
            Board board = new Board(true);
            board[7, 7] = new King(false, new Point(7, 7));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0]= new Rook(false, new Point(0, 0));
            board[0, 0].Move(new Point(0, 7), board);
            bool f = board[0, 7] is Rook;
            Assert.AreEqual(true, f);
        }

        [TestMethod]
        public void MoveBlackUpRookMethod()
        {
            Board board = new Board(true);
            board[7, 7] = new King(false, new Point(7, 7));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0] = new Rook(true, new Point(0, 0));
            board[0, 0].Move(new Point(0, 7), board);
            Assert.AreEqual(true, board[0, 7] is Rook);
        }

        [TestMethod]
        public void MoveWhiteRightRookMethod()
        {
            Board board = new Board(true);
                        board[7, 7] = new King(false, new Point(7, 7));
                        board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0] = new Rook(false, new Point(0, 0));
            board[0, 0].Move(new Point(7, 0), board);
            Assert.AreEqual(true, board[7, 0] is Rook);
        }

        [TestMethod]
        public void MoveBlackRightRookMethod()
        {
            Board board = new Board(true);
            board[7, 7] = new King(false, new Point(7, 7));
            board[7, 0] = new King(true, new Point(7, 0));
            board[0, 0] = new Rook(true, new Point(0, 0));
            board[0, 0].Move(new Point(6, 0), board);
            Assert.AreEqual(true, board[6, 0] is Rook);
        }

    }
}
