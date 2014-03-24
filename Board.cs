using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing
{
    class Board
    {
        public int VSize = 9;
        public int HSize = 9;
        public int CrossLength = 5;
        public int Binc = 3;
        public Ball[,] Balls = new Ball[9, 9];

        public Board(List<BallPosition> bps, int binc)
        {
            this.Balls = new Ball[VSize, HSize];
            this.Binc = binc;

            for (int i = 0; i < bps.Count; i++)
            {
                this.Balls[bps[i].Position.Top, bps[i].Position.Left] = bps[i].Ball;
            }
        }

        public void SetBall(BallPosition bp)
        {
            this.Balls[bp.Position.Top, bp.Position.Left] = bp.Ball;
        }

        public void GenerateInsertBall()
        {
            BallPosition bp = this.GenerateBall();
            this.SetBall(bp);
        }

        public void GenerateInsertBall(int c)
        {
            for (int i = 0; i < c; i++)
            {
                this.GenerateInsertBall();
            }
        }

        public BallPosition GenerateBall()
        {
            List<Position> fp = this.getFree();

            if (1 > fp.Count)
            {
                throw new Exception("No free cells");
            }

            Position p = Support.SRandom.Random<Position>(fp);

            Ball b = Ball.Random();
            BallPosition bp = new BallPosition();
            bp.Ball = b;
            bp.Position = p;

            return bp;
        }

        public bool Move(Position from, Position to)
        {
            List<Position> moves = this.getMoves(from);
            bool cont = false;
            for (int i = 0; i < moves.Count; i++)
            {
                if (to.Left == moves[i].Left &&
                    to.Top == moves[i].Top)
                {
                    cont = true;
                    break;
                }
            }

            if (!cont)
            {
                return false;
            }

            Ball temp = this.Balls[to.Top, to.Left];

            this.Balls[to.Top, to.Left] = this.Balls[from.Top, from.Left];
            this.Balls[from.Top, from.Left] = temp;

            return true;
        }

        public List<Position> getFree()
        {
            List<Position> lp = new List<Position>();

            for (int i = 0; i < VSize; i++)
            {
                for (int j = 0; j < HSize; j++)
                {
                    if (null == this.Balls[i, j])
                    {
                        lp.Add(new Position() {
                            Left = j,
                            Top = i
                        });
                    }
                }
            }

            return lp;
        }

        public List<Position> getMoves(Position from)
        {
            List<Position> lp = new List<Position>();

            Position pr = new Position()
            {
                Left = 1,
                Top = 0
            };

            Position pd = new Position()
            {
                Left = 0,
                Top = 1
            };

            bool[,] bp = new bool[VSize, HSize];

            getNextMoves(ref pr, ref bp, ref lp);
            getNextMoves(ref pd, ref bp, ref lp);

            return lp;
        }

        private void getNextMoves(ref Position from, ref bool[,] bp, ref List<Position> lp)
        {
            if (bp[from.Top, from.Left] || null != this.Balls[from.Top, from.Left])
            {
                return;
            }

            lp.Add(from);
            bp[from.Top, from.Left] = true;

            if (from.Left < HSize - 1)
            {
                Position pr = new Position() {
                    Left = from.Left+1,
                    Top = from.Top
                };

                getNextMoves(ref pr, ref bp, ref lp);
            }

            if (from.Top < VSize - 1)
            {
                Position pd = new Position()
                {
                    Left = from.Left,
                    Top = from.Top + 1
                };

                getNextMoves(ref pd, ref bp, ref lp);
            }
        }

        public int CaclucateCrosses()
        {
            int crosses = 0;

            for (int i = 0; i < this.HSize; i++)
            {
                crosses += CalculateBottom(0, i, 0, 0);
                crosses += CalculateDiagonal(0, i, 0, 0);
                crosses += CalculateBackDiagonal(this.VSize, i, 0, 0);
            }

            for (int i = 0; i < this.VSize; i++)
            {
                crosses += CalculateRight(i, 0, 0, 0);
                crosses += CalculateDiagonal(i, 0, 0, 0);
                crosses += CalculateBackDiagonal(i, 0, 0, 0);
            }

            return crosses;
        }

        private int CalculateRight(int top, int left, int length, int crosses)
        {
            if (this.CrossLength == length)
            {
                crosses++;
                length = 0;

                for (int i = 1; i <= this.CrossLength; i++)
                {
                    this.Balls[top, left - i] = null;
                }
            }

            if (left >= this.HSize)
            {
                return crosses;
            }

            if (null != this.Balls[top, left] && (0 == length || (null != this.Balls[top, left - 1] && this.Balls[top, left].Color == this.Balls[top, left - 1].Color)))
            {
                return CalculateRight(top, left + 1, ++length, crosses);
            }
            else
            {
                return CalculateRight(top, left + 1, 0, crosses);
            }
        }

        //NOT TESTED, NOT WORKING
        private int CalculateBottom(int top, int left, int length, int crosses)
        {
            if (this.CrossLength == length)
            {
                crosses++;
                length = 0;

                for (int i = 1; i <= this.CrossLength; i++)
                {
                    this.Balls[top - i, left] = null;
                }
            }

            if (top >= this.VSize)
            {
                return crosses;
            }

            if (null != this.Balls[top, left] && (0 == length || (null != this.Balls[top - 1, left] && this.Balls[top, left].Color == this.Balls[top - 1, left].Color)))
            {
                return CalculateBottom(top + 1, left, ++length, crosses);
            }
            else
            {
                return CalculateBottom(top + 1, left, 0, crosses);
            }
        }

        //NOT TESTED, NOT WORKING
        private int CalculateDiagonal(int top, int left, int length, int crosses)
        {
            if (this.CrossLength == length)
            {
                crosses++;
                length = 0;

                for (int i = 1; i <= this.CrossLength; i++)
                {
                    this.Balls[top - i, left - i] = null;
                }
            }

            if (top >= this.VSize || left >= this.HSize)
            {
                return crosses;
            }

            if (null != this.Balls[top, left] && (0 == length || (null != this.Balls[top - 1, left - 1] && this.Balls[top, left].Color == this.Balls[top - 1, left -1].Color)))
            {
                return CalculateDiagonal(top + 1, left + 1, ++length, crosses);
            }
            else
            {
                return CalculateDiagonal(top + 1, left + 1, 0, crosses);
            }
        }

        private int CalculateBackDiagonal(int top, int left, int length, int crosses)
        {
            if (this.CrossLength == length)
            {
                crosses++;
                length = 0;

                for (int i = 1; i <= this.CrossLength; i++)
                {
                    this.Balls[top + i, left - i] = null;
                }
            }

            if (top >= this.VSize || left <= 0)
            {
                return crosses;
            }

            if (null != this.Balls[top, left] && (0 == length || (null != this.Balls[top + 1, left - 1] && this.Balls[top, left].Color == this.Balls[top + 1, left - 1].Color)))
            {
                return CalculateBackDiagonal(top - 1, left + 1, ++length, crosses);
            }
            else
            {
                return CalculateBackDiagonal(top - 1, left + 1, 0, crosses);
            }
        }

        public override string ToString()
        {
            String s = "";

            for (int i = 0; i < VSize; i++)
            {
                for (int j = 0; j < HSize; j++)
                {
                    if (null == this.Balls[i, j])
                    {
                        s += "--";
                    }
                    else
                    {
                        s += this.Balls[i, j];
                    }

                    s += " ";
                }
                s += "\n";
            }

            return s;
        }
    }
}
