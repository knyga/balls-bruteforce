using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing
{
    class Position
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public override string ToString()
        {
            return String.Format("{0}, {1}", Top, Left);
        }
    }
}
