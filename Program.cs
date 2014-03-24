using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallsKing
{
    class Program
    {
        static void Main(string[] args)
        {
            Board br = new Board(new List<BallPosition>() {
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 0,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 1,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 2,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 3,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 4,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 5,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 6,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 7,
                        Top = 0
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 7,
                        Top = 1
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 7,
                        Top = 2
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 7,
                        Top = 3
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 7,
                        Top = 4
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 1,
                        Top = 7
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 2,
                        Top = 6
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 3,
                        Top = 5
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 4,
                        Top = 4
                    }
                },
                new BallPosition() {
                    Ball = new Ball() {
                        Color = Color.RED
                    },
                    Position = new Position() {
                        Left = 5,
                        Top = 3
                    }
                },

            }, 3);

            Node root = new Node()
            {
                Board = br
            };

            Console.Write(br.CaclucateCrosses());


            //LOOK ON DIAGONAL, IT IS NOT MERGED
            Console.Write(br);


        }
    }
}
