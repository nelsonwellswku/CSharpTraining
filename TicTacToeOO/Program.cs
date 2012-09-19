using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player("X");
            Player playerTwo = new Player("O");
            Board board = new Board();

            Game game = new Game(board, playerOne, playerTwo);
            game.Play();
        }
    }
}
