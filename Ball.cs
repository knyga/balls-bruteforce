using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing
{
    class Ball
    {
        public Color Color { get; set; }
        private static Random rnd = new Random();

        private static Color GenerateRandomColor()
        {
            int p = rnd.Next(0, 7);

            switch (p)
            {
                case 0:
                    return Color.BLUE;
                case 1:
                    return Color.BROWN;
                case 2:
                    return Color.CYAN;
                case 3:
                    return Color.GREEN;
                case 4:
                    return Color.PINK;
                case 5:
                    return Color.RED;
                case 6:
                    return Color.YELLOW;
            }

            return Color.UNDEFINED;
        }

        public static Ball Random()
        {
            Ball b = new Ball();
            b.Color = GenerateRandomColor();
            return b;
        }

        public override string ToString()
        {
            String c = "";

            switch (this.Color)
            {
                case Color.BLUE: return "bl";
                case Color.BROWN: return "br";
                case Color.CYAN: return "cy";
                case Color.GREEN: return "gr";
                case Color.PINK: return "pi";
                case Color.RED: return "rd";
                case Color.YELLOW: return "yl";
            }

            return "un";
        }
    }
}