using System;
using TicTacToe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ToggleTurn_Changed()
        {
            Assert.AreEqual<bool>(false, Program.GetTurn());
            Program.ToggleTurn();
            Assert.AreEqual<bool>(true, Program.GetTurn());
        }

        [TestMethod]
        public void SetPiece_Works()
        {
            Assert.AreEqual<string>("2", Program.GetPiece(0, 2));
            Assert.AreEqual<bool>(true, Program.ManipulateBoard(2));            
        }
    }
}
