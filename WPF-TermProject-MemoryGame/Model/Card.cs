using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TermProject_MemoryGame.Model
{
    public class Card
    {
        public string ImageFront { get; set; }
        public string ImageBack { get; set; }
        public bool IsFaceUp { get; set; }
        public bool IsMatched { get; set; }
    }
}