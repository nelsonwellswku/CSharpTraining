using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Program
    {
        static bool turn = false;
        static bool gameOver = false;
        static int[,] board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static int turnCount = 0;

        public static void Main(string[] args)
        {
            int userInput = -2;
            bool wasBoardManipulated = false;
            while (!gameOver)
            {
                Console.Clear();
                DrawBoard();

                do
                {
                    while (userInput < 1 || userInput > 9)
                    {
                        System.Console.WriteLine("Enter spot");
                        userInput = GetUserInput();
                    }

                    wasBoardManipulated = ManipulateBoard(userInput);
                    userInput = -2;
                    System.Console.WriteLine(wasBoardManipulated);
                } while (!wasBoardManipulated);

                turnCount++;
                ToggleTurn();                

                gameOver = IsGameOver();

            }
            Console.Clear();
            DrawBoard();
            
            System.Console.WriteLine("Good game!");
            if (turnCount > 9)
            {
                System.Console.WriteLine("It was a tie!");
            }
            else if (turn == true)
            {
                System.Console.WriteLine("X wins!");
            }
            else
            {
                System.Console.WriteLine("O wins!");
            }
        }

        public static void DrawBoard()
        {
            Console.WriteLine(" ____________");
            int number = 1;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(
                   String.Format("|_{0}_|_{1}_|_{2}_|",
                        GetPiece(board[i,0],number++),
                        GetPiece(board[i,1],number++),
                        GetPiece(board[i,2],number++)
                    )
                );
                
            }
        }

        public static string GetPiece(int coordinate, int number)
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

        public static int GetUserInput()
        {
            int value;
            int.TryParse(System.Console.ReadLine(), out value);
            
            if (value <= 0 || value >= 10)
            {
                return -1;
            }
            else
            {
                return value;
            }
        }

        public static bool GetTurn()
        {
            return turn;
        }

        public static void ToggleTurn()
        {
            turn = !turn;
        }

        public static bool IsGameOver()
        {

            bool tiedGame = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
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
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && (board[i, 1] == 1 || board[i, 1] == -1))
                {
                    return true;
                }
            }

            // check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == board[1, j] && board[1, j] == board[2, j] && (board[1, j] == 1 || board[1, j] == -1))
                {
                    return true;
                }
            }

            // check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && (board[1, 1] == 1 || board[1, 1] == -1))
            {
                return true;
            }

            if (board[2, 2] == board[1, 1] && board[1, 1] == board[2, 0] && (board[1, 1] == 1 || board[1, 1] == -1))
            {
                return true;
            }

            return false;
        }

        public static bool ManipulateBoard(int choice)
        {
            //turn - false X - 
           //       true  O
           //1-3 = 0,(num-1) .... 4-6 = 1,(num-4) .... 7-9 = 2,(num-7)
            int piece = 1;
            if (turn)
            {
                piece = -1;
            }

            if (choice >= 1 && choice <= 3)
            {
                if(board[0, (choice - 1)] == 0)
                {
                    board[0, (choice - 1)] = piece;
                    return true;
                }
                
            }
            else if (choice >= 4 && choice <= 6)
            {
                if (board[1, (choice - 4)] == 0)
                {
                    board[1, (choice - 4)] = piece;
                    return true;
                }
            }
            else
            {
                if (board[2, (choice - 7)] == 0)
                {
                    board[2, (choice - 7)] = piece;
                    return true;
                }
            }

            return false;
        }
    }
}
