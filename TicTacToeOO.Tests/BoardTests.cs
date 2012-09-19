using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TicTacToeOO;

namespace TicTacToeOO.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void ModifyBoard_ModifyFiveWithO_Success()
        {
            Board board = new Board();
            Assert.AreEqual<bool>(true, board.ModifyBoard(5, "O"));
        }

        [TestMethod]
        public void CheckForWinner_NoWinner_ReturnFalse()
        {
            Board board = new Board();
            Assert.AreEqual<bool>(false, board.CheckForWinner());
        }

        [TestMethod]
        public void CheckForWinner_TopRowWinner_Success()
        {
            Board board = new Board();
            board.ModifyBoard(1, "X");
            board.ModifyBoard(2, "X");
            board.ModifyBoard(3, "X");

            Assert.AreEqual<bool>(true, board.CheckForWinner());
        }
    }
}
