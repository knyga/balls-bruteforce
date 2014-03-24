using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing
{
    class TreeOfPosibilities
    {
        public Node Root { get; set; }
        public int Depth { get; set; }
        public Node FindMove()
        {
            IEnumerable<Node> nodes = Root.getChildren();
            Node maxNode = null;
            double maxVal = 0;
            foreach(Node n in nodes) {
                if (maxVal < n.Crossed)
                {
                    maxNode = n;
                    maxVal = n.Crossed;
                }
            }

            return maxNode;
        }


    }
}
