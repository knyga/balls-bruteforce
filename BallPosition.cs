using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing
{
    class BallPosition
    {
        public Ball Ball { get; set; }
        public Position Position { get; set; }
        public override string ToString()
        {
            return String.Format("{0}, {1}", Position, Ball);
        }
    }
}
