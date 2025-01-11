using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TermProject_MemoryGame.Model
{
    public class Player
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public bool IsPicked { get; set; }

        public Player() { }
        public Player(int id, bool isPicked)
        {
            Id = id;
            IsPicked = isPicked;
            Score = 0;
        }
    }
}