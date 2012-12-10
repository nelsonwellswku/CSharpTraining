using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOO
{
    public class Board
    {
        private int[,] TTTBoard { get; set; }

        public Board()
        {
            TTTBoard = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        private string GetPiece(int coordinate, int number)
        {
            if (coordinate == 0)
            {
                return number.ToString();
            }
            else if (coordinate == 1)
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

        public void DrawBoard()
        {
            Console.WriteLine(" ____________");
            int number = 1;
            for (int i = 0; i < 3; i++)
            {
                
                Console.WriteLine(
                   String.Format("|_{0}_|_{1}_|_{2}_|",
                        GetPiece(TTTBoard[i, 0], number++),
                        GetPiece(TTTBoard[i, 1], number++),
                        GetPiece(TTTBoard[i, 2], number++)
                    )
                );

            }
        }

        public bool CheckForWinner()
        {
            
            bool tiedGame = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (TTTBoard[i, j] == 0)
                    {
                        tiedGame = false;
                    }
                }
            }

            if (tiedGame)
            {
                return true;
            }

            // check rows
            for (int i = 0; i < 3; i++)
            {
                if (TTTBoard[i, 0] == TTTBoard[i, 1] && TTTBoard[i, 1] == TTTBoard[i, 2] && (TTTBoard[i, 1] == 1 || TTTBoard[i, 1] == -1))
                {
                    return true;
                }
            }

            // check columns
            for (int j = 0; j < 3; j++)
            {
                if (TTTBoard[0, j] == TTTBoard[1, j] && TTTBoard[1, j] == TTTBoard[2, j] && (TTTBoard[1, j] == 1 || TTTBoard[1, j] == -1))
                {
                    return true;
                }
            }

            // check diagonals
            if (TTTBoard[0, 0] == TTTBoard[1, 1] && TTTBoard[1, 1] == TTTBoard[2, 2] && (TTTBoard[1, 1] == 1 || TTTBoard[1, 1] == -1))
            {
                return true;
            }

            if (TTTBoard[2, 2] == TTTBoard[1, 1] && TTTBoard[1, 1] == TTTBoard[2, 0] && (TTTBoard[1, 1] == 1 || TTTBoard[1, 1] == -1))
            {
                return true;
            }

            return false;
        
        }

        public bool ModifyBoard(int choice, string symbol)
        {
            int piece = (symbol == "X") ? 1 : -1;           

            if (choice >= 1 && choice <= 3)
            {
                if (TTTBoard[0, (choice - 1)] == 0)
                {
                    TTTBoard[0, (choice - 1)] = piece;
                    return true;
                }

            }
            else if (choice >= 4 && choice <= 6)
            {
                if (TTTBoard[1, (choice - 4)] == 0)
                {
                    TTTBoard[1, (choice - 4)] = piece;
                    return true;
                }
            }
            else
            {
                if (TTTBoard[2, (choice - 7)] == 0)
                {
                    TTTBoard[2, (choice - 7)] = piece;
                    return true;
                }
            }

            return false;
        }
    }
}
