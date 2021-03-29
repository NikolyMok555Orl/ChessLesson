using System;
using System.Drawing;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTestProject
{
    [TestClass]
    public class QueenTest
    {
        [TestMethod]
        public void CanMoveFreeDiagonalBoardWhite()
        {
            Board board = new Board(true);
            board[7, 7] = new King(false, new Point(7, 7));
            board[0, 7] = new King(true, new Point(7, 0));
            board[1, 0] = new Queen(false, new Point(1, 0));
            bool f = board[1, 0].CanMove(new Point(4, 3), board);
            Assert.AreEqual(true, f);
            board[1, 0].Move(new Point(4, 3), board);
            Assert.AreEqual("0123Qw567", board.ToStringLine(3));
        }


        [TestMethod]
        public void CanMoveFreeDiagonalBoardBlack()
        {
            Board board = new Board(true);
            board[7, 7] = new King(false, new Point(7, 7));
            board[7, 0] = new King(true, new Point(7, 0));
            board[2, 7] = new Queen(true, new Point(2, 7));
            Assert.AreEqual(true, board[2, 7].CanMove(new Point(4, 5), board));
            board[2, 7].Move(new Point(4, 5), board);
            Assert.AreEqual("0123Qb567", board.ToStringLine(5));
        }


        [TestMethod]
        public void CanMoveQueenBoardWhite()
        {
            Board board = new Board(true);
                        board[7, 7] = new King(false, new Point(7, 7));
                        board[7, 0] = new King(true, new Point(7, 0));
            board[2, 0] = new Queen(false, new Point(2, 0));
            Assert.AreEqual(true, board[2, 0].CanMove(new Point(3, 1), board));
        }


        


        [TestMethod]
        public void NotCanMoveAsRookBoardWhite()
        {
            Board board = new Board(true);
            board[4, 0] = new Queen(false, new Point(4, 0));
            board[4, 5] = new Pawn(true, new Point(4, 5));
            Assert.AreEqual(false, board[4, 0].CanMove(new Point(4, 6), board));
        }

        [TestMethod]
        public void NotCanMoveAsRookBoardBlack()
        {
            Board board = new Board(true);
            board[4, 7] = new Queen(false, new Point(4, 7));
            board[4, 5] = new Pawn(true, new Point(4, 5));
            Assert.AreEqual(false, board[4, 7].CanMove(new Point(4, 1), board));
        }





        [TestMethod]
        public void MoveWhiteOneQueenMethod()
        {
            Board board = new Board();
            board[0, 1].Move(new Point(0, 2), board);
            board[0, 0].Move(new Point(0, 1), board);


            Assert.AreEqual("RwPwPwPwPwPwPwPw", board.ToStringLine(1));
        }

        [TestMethod]
        public void MoveBlackOneQueenMethod()
        {
            Board board = new Board();
            board[0, 6].Move(new Point(0, 5), board);
            board[0, 7].Move(new Point(0, 6), board);

            Assert.AreEqual("RbPbPbPbPbPbPbPb", board.ToStringLine(6));
        }
    }
}
