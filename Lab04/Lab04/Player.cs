using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04
{
    public class Player
    {
        
        public Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
