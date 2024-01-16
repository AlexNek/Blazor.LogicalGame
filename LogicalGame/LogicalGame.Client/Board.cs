namespace LogicalGame.Client
{
    internal class Board
    {
        public const int RotateGlobalRight = 0;
        public const int RotateGlobalLeft = 1;
        public const int RotateLeftSide = 2;
        public const int RotateRightSide = 3;

        private readonly string?[,] _board;
        //private string?[,] _board = new string?[,]
        //                               {
        //                                   { "1", null, null, null, null, "8" }, 
        //                                   { null,  "2", null, null, "7", null },
        //                                   { null, null,"3" , "6", null, null },
        //                                   { null, "4", null, null, "10", null },
        //                                   { "5", null, null, null, null, "9" }
        //                               };

        private readonly Position[] _globalCircle =
            {
                new Position(0, 0), 
                new Position(0, 5), 
                new Position(4, 5), 
                new Position(4, 0),
            };

        private readonly Position[] _leftCircle =
            {
                new Position(0, 0), 
                new Position(1, 1), 
                new Position(2, 2), 
                new Position(3, 1), 
                new Position(4, 0),
                //new Position(4, 0),
                //new Position(3, 1),
                //new Position(2, 2),
                //new Position(1, 1)
            };

        private readonly Position[] _rightCircle =
            {
                new Position(2, 3),
                new Position(1, 4),
                new Position(0, 5),
                new Position(4, 5),
                new Position(3, 4),
            };

        public Board(string?[,] initialState)
        {
            _board = initialState;
        }

        /// <summary>
        /// Gets the value by index.
        /// </summary>
        /// <param name="index">The index. 1..10</param>
        /// <returns>System.Nullable&lt;System.String&gt;.</returns>
        public string? GetValueByIndex(int index)
        {
            index--;
            if (index < 0 || index >= 10)
            {
                return "-1";
            }

            Position pos = null;
            if (index<5)
            {
                pos = _leftCircle[index];
            }
            else
            {
                pos = _rightCircle[index - 5];
            }

            return _board[pos.Row, pos.Col];
        }

        public void Print()
        {
            for (int row = 0; row < _board.GetLength(0); row++)
            {
                for (int col = 0; col < _board.GetLength(1); col++)
                {
                    string s = _board[row, col];
                    if (string.IsNullOrEmpty(s))
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write($"{s:2} ");
                    }
                }

                Console.WriteLine();
            }
        }

        public void Rotate(int type)
        {
            switch (type)
            {
                case 0:
                    RotateGlobalR();
                    break;
                case 1:
                    RotateGlobalL();
                    break;
                case 2:
                    RotateLeftSmall();
                    break;
                case 3:
                    RotateRightSmall();
                    break;
            }
        }
        //public class Moving
        //{
        //    public Position From { get; set; }
        //    public Position To { get; set; }
        //}

       

        private void RotateGlobalL()
        {
            Console.WriteLine("Global L");
            RoundMoveL(_globalCircle);

            Print();
        }

        private void RotateGlobalR()
        {
            Console.WriteLine("Global R");
            RoundMoveR(_globalCircle);
            Print();
        }

        private void RotateLeftSmall()
        {
            Console.WriteLine("Left");
            RoundMoveL(_leftCircle);
            Print();
        }

        private void RotateRightSmall()
        {
            Console.WriteLine("Right");
            RoundMoveR(_rightCircle);
            Print();
        }

        private void RoundMoveL(Position[] steps)
        {
            if (steps.Length < 2)
            {
                return;
            }

            string? lastValue = null;

            if (steps.Any())
            {
                Position firstStep = steps[0];
                lastValue = _board[firstStep.Row, firstStep.Col];
            }

            for (int i = 0; i < steps.Length - 1; i++)
            {
                Position step = steps[i];
                Position nextStep = steps[i + 1];
                // copy from-->to
                _board[step.Row, step.Col] = _board[nextStep.Row, nextStep.Col];
            }

            if (steps.Any())
            {
                Position lastStep = steps[steps.Length - 1];
                if (lastValue != null)
                {
                    _board[lastStep.Row, lastStep.Col] = lastValue;
                }
            }
        }

        private void RoundMoveR(Position[] steps)
        {
            if (steps.Length < 2)
            {
                return;
            }

            string? lastValue = null;

            if (steps.Any())
            {
                Position lastStep = steps[steps.Length - 1];
                lastValue = _board[lastStep.Row, lastStep.Col];
            }

            for (int i = steps.Length - 1; i > 0; i--)
            {
                Position step = steps[i];
                Position prevStep = steps[i - 1];
                // copy from-->to
                _board[step.Row, step.Col] = _board[prevStep.Row, prevStep.Col];
            }

            if (steps.Any())
            {
                Position firstStep = steps[0];
                if (lastValue != null)
                {
                    _board[firstStep.Row, firstStep.Col] = lastValue;
                }
            }
        }

        private record Position(int Row, int Col);
    }
}
