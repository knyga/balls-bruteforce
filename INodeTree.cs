using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing
{
    interface INodeTree<T>
    {
        void setParent(T node);
        T getParent();
        void addChild(T node);
        T getChild(int i);
        int getCount();
        IEnumerable<T> getChildren();
        IEnumerator<T> getChildrenEnumerator();
    }
}
