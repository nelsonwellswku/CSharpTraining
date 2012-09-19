using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOO
{
    public class Player
    {
        public string Symbol { get; set; }

        public Player(string symbol)
        {
            Symbol = symbol;
        }

        public int GetPlayerMoveSelection()
        {
            int value = 0;
            
            while(value <= 0 || value >= 10)
            {
                Console.WriteLine("Make a move! [1-9]");
                int.TryParse(System.Console.ReadLine(), out value);
            }

            return value;
        }

    }
}
