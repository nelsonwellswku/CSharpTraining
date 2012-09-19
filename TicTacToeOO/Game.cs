using System;
using System.Text;

namespace TicTacToeOO
{
    public class Game
    {

        private bool _GameOver { get; set; }
        private Player CurrentPlayerTurn { get; set; }
        
        public Player PlayerOne;
        public Player PlayerTwo;

        public Board Board;

        public Game(Board board, Player playerOne, Player playerTwo)
        {
            Board = board;
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            CurrentPlayerTurn = playerOne;

            _GameOver = false;
        }

        public void Play()
        {
            int moveSelection = 0;

            do
            {
                Console.Clear();
                Board.DrawBoard();
                moveSelection = CurrentPlayerTurn.GetPlayerMoveSelection();
                Board.ModifyBoard(moveSelection, CurrentPlayerTurn.Symbol);
                _GameOver = Board.CheckForWinner();

                CurrentPlayerTurn = (CurrentPlayerTurn.GetHashCode() == PlayerOne.GetHashCode()) ? PlayerTwo : PlayerOne;
            } while (!_GameOver);

            Console.Clear();
            Board.DrawBoard();
            Console.WriteLine("Good game!");
            Console.ReadLine();
        }
    }
}
