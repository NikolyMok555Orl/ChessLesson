using System;
using System.Drawing;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ChessTestProject
{
    [TestClass]
    public class FigurePawnTest
    {
        //"01234567"
        //тест на проходку
        [TestMethod]
        public void MoveWhiteOnePawnMethod()
        {
            Board board = new Board();
            board[0, 1].Move(new Point(0,2), board);
            Assert.AreEqual("Pw1234567", board.ToStringLine(2));
        }

        [TestMethod]
        public void MoveBlackOnePawnMethod()
        {
            Board board = new Board();
            board[1, 6].Move(new Point(1, 5), board);
            Assert.AreEqual("0Pb234567", board.ToStringLine(5));
        }

        [TestMethod]
        public void MoveWhiteOneBackFalsePawnMethod()
        {
            Board board = new Board();
            board[0, 1].Move(new Point(0, 0), board);
            Assert.AreEqual("RwHwBwQwKwBwHwRw", board.ToStringLine(0));
        }

        [TestMethod]
        public void MoveBlackOneBackFalsePawnMethod()
        {
            Board board = new Board();
            board[1, 6].Move(new Point(1, 7), board);
            Assert.AreEqual("RbHbBbQbKbBbHbRb", board.ToStringLine(7));
        }

        [TestMethod]
        public void MoveWhiteTwoTruePawnMethod()
        {
            Board board = new Board();
            board[0, 1].Move(new Point(0, 3), board);
            Assert.AreEqual("Pw1234567", board.ToStringLine(3));
        }

        [TestMethod]
        public void MoveBlackTwoTruePawnMethod()
        {
            Board board = new Board();
            board[0, 6].Move(new Point(0, 4), board);
            Assert.AreEqual("Pb1234567", board.ToStringLine(4));
        }

        [TestMethod]
        public void MoveWhiteTwoFalsePawnMethod()
        {
            Board board = new Board();
            board[0, 1].Move(new Point(0, 2), board);
            board[0, 2].Move(new Point(0, 4), board);
            Assert.AreEqual("01234567", board.ToStringLine(4));
        }

        [TestMethod]
        public void MoveBlackTwoFalsePawnMethod()
        {
            Board board = new Board();
            board[0, 6].Move(new Point(0, 5), board);
            board[0, 5].Move(new Point(0, 3), board);
            Assert.AreEqual("01234567", board.ToStringLine(3));
        }

        [TestMethod]
        public void MoveWhiteDiagonalFalsePawnMethod()
        {
            Board board = new Board();
            board[0, 1].Move(new Point(1, 2), board);
           
            Assert.AreEqual("01234567", board.ToStringLine(3));
        }

        [TestMethod]
        public void MoveWhiteDiagonalTruePawnMethod()
        {
            Board board = new Board();

            for (int i = 6; i > 2; i--)
            {
                board[1, i].Move(new Point(1, i-1), board);
            }
            board[0, 1].Move(new Point(1, 2), board);


            Assert.AreEqual("0Pw234567", board.ToStringLine(2));
        }
    }
}
