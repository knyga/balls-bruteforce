using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace BallsKing
{
    class Node: INodeTree<Node>, IComparable<Node>
    {
        private static MD5 md5 = MD5.Create();

        public Board Board { get; set; }
        public List<BallPosition> Generated { get; set; }
        public Position from { get; set; }
        public Position to { get; set; }
        public double Crossed { get; set; }

        private string id;
        public string Id
        {
            get
            {
                if (String.IsNullOrEmpty(id))
                {
                    String strword = "";

                    foreach (BallPosition bp in Generated)
                    {
                        strword += bp;
                    }

                    strword += from;
                    strword += to;

                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("x2"));
                    }
                    
                    id = sb.ToString();
                }

                return id;
            }
        }

        #region Compare
        public int CompareTo(Node n)
        {
            return n.Id == this.id ? 0 : -1;
        }
        #endregion

        #region Tree
        LinkedList<Node> nodes = new LinkedList<Node>();
        Node parent;
        public void setParent(Node node)
        {
            parent = node;
        }
        public Node getParent()
        {
            return parent;
        }
        public void addChild(Node node)
        {
            nodes.AddLast(node);
        }
        public Node getChild(int p)
        {
            IEnumerator<Node> it = nodes.GetEnumerator();
            for(int i=0;i<p;i++) {
                it.MoveNext();
            }

            if (!it.MoveNext())
            {
                throw new IndexOutOfRangeException();
            }

            return it.Current;

        }
        public int getCount()
        {
            return nodes.Count;
        }

        public IEnumerable<Node> getChildren()
        {
            return nodes;
        }

        public IEnumerator<Node> getChildrenEnumerator()
        {
            return nodes.GetEnumerator();
        }
        #endregion

        #region CrossedRecalculation
        public void CrossedRecalculation()
        {
            if (null == this.nodes)
            {
                return;
            }

            int count = 0;
            double sum = 0;

            foreach (Node node in this.nodes)
            {
                if (null != node.nodes)
                {
                    node.CrossedRecalculation();
                }
                else
                {
                    node.Crossed = node.Board.CaclucateCrosses();
                }

                count++;
                sum += node.Crossed;
            }
        }
        #endregion
    }
}
