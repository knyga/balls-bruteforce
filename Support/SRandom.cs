using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing.Support
{
    class SRandom
    {
        private static Random rnd = new Random();

        public static T Random<T>(List<T> lst)
        {
            int rint = rnd.Next(lst.Count);

            return lst[rint];
        }
    }
}
