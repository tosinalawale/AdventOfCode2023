namespace AdventOfCode2023.Day17
{
    public class Day17PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            int[,] valueGrid = ParseIntGrid(input);

            (int row, int col) startPosition = (row: 0, col: 0);
            (int row, int col) endPosition = (row: input.Length - 1, col: input[0].Length - 1);

            int result = FindShortestDistanceToDestinationUsingDijkstra(valueGrid, startPosition, endPosition);

            return result;
        }

        private static int FindShortestDistanceToDestinationUsingDijkstra(
            int[,] valueGrid,
            (int row, int col) startPosition,
            (int row, int col) endPosition)
        {
            Dictionary<Node, int> distances = new();
            PriorityQueue<Node, int> queue = new();

            Node startingNode = new()
            {
                Position = (startPosition.row, startPosition.col),
                StraightStepsSoFar = 0,
                Direction = '>',
            };

            distances.Add(startingNode, 0);
            queue.Enqueue(startingNode, 0);

            while (queue.TryDequeue(out Node? currentNode, out int currentDistance))
            {
                if (currentNode.Position.row == endPosition.row && currentNode.Position.col == endPosition.col)
                {
                    if (currentNode.StraightStepsSoFar >= 4) return currentDistance;
                    else continue;
                }

                foreach (Node neighbourNode in GetAdjacentPositions(valueGrid, currentNode))
                {
                    int newDistance = distances[currentNode] + valueGrid[neighbourNode.Position.row, neighbourNode.Position.col];

                    if (newDistance < distances.GetValueOrDefault(neighbourNode, int.MaxValue))
                    {
                        distances[neighbourNode] = newDistance;
                        queue.Enqueue(neighbourNode, newDistance);
                    }
                }
            }

            return int.MaxValue;
        }

        private static char DetermineDirection((int row, int col) currentPos, (int row, int col) neighbourPos)
        {
            if (currentPos.row == neighbourPos.row)
            {
                return neighbourPos.col > currentPos.col ? '>' : '<';
            }
            else
            {
                return neighbourPos.row > currentPos.row ? 'V' : '^';
            }
        }

        private static List<Node> GetAdjacentPositions(int[,] valueGrid, Node currentNode)
        {
            int currentRow = currentNode.Position.row;
            int currentCol = currentNode.Position.col;

            List<Node> adjacentPositions = new();
            int gridWidth = valueGrid.GetLength(1);
            int gridHeight = valueGrid.GetLength(0);

            if (currentCol < gridWidth - 1
                && CanMoveToNextPosition(currentNode, (row: currentRow, col: currentCol + 1)))
                adjacentPositions.Add(new Node
                {
                    Position = (currentRow, currentCol + 1),
                    Direction = DetermineDirection((currentRow, currentCol), (currentRow, currentCol + 1)),
                    StraightStepsSoFar =
                        currentNode.Direction == DetermineDirection((currentRow, currentCol), (currentRow, currentCol + 1))
                            ? currentNode.StraightStepsSoFar + 1
                            : 1
                });

            if (currentCol > 0
                && CanMoveToNextPosition(currentNode, (row: currentRow, col: currentCol - 1)))
                adjacentPositions.Add(new Node
                {
                    Position = (currentRow, currentCol - 1),
                    Direction = DetermineDirection((currentRow, currentCol), (currentRow, currentCol - 1)),
                    StraightStepsSoFar =
                        currentNode.Direction == DetermineDirection((currentRow, currentCol), (currentRow, currentCol - 1))
                            ? currentNode.StraightStepsSoFar + 1
                            : 1
                });


            if (currentRow < gridHeight - 1
                && CanMoveToNextPosition(currentNode, (row: currentRow + 1, col: currentCol)))
                adjacentPositions.Add(new Node
                {
                    Position = (currentRow + 1, currentCol),
                    Direction = DetermineDirection((currentRow, currentCol), (currentRow + 1, currentCol)),
                    StraightStepsSoFar =
                        currentNode.Direction == DetermineDirection((currentRow, currentCol), (currentRow + 1, currentCol))
                            ? currentNode.StraightStepsSoFar + 1
                            : 1
                });

            if (currentRow > 0
                && CanMoveToNextPosition(currentNode, (row: currentRow - 1, col: currentCol)))
                adjacentPositions.Add(new Node
                {
                    Position = (currentRow - 1, currentCol),
                    Direction = DetermineDirection((currentRow, currentCol), (currentRow - 1, currentCol)),
                    StraightStepsSoFar =
                        currentNode.Direction == DetermineDirection((currentRow, currentCol), (currentRow - 1, currentCol))
                        ? currentNode.StraightStepsSoFar + 1
                        : 1
                });

            return adjacentPositions;
        }

        private static bool CanMoveToNextPosition(Node currentNode,
            (int row, int col) nextPosition)
        {
            char newDirection = DetermineDirection(currentNode.Position, nextPosition);
            char oppositeDirection = currentNode.Direction switch
            {
                '>' => '<',
                '<' => '>',
                'V' => '^',
                '^' => 'V',
                _ => throw new Exception("Invalid direction"),
            };

            return ((currentNode.Direction == newDirection && currentNode.StraightStepsSoFar < 10)
                    || (currentNode.Direction != newDirection && currentNode.StraightStepsSoFar >= 4))
                   && newDirection != oppositeDirection;
        }

        private static int[,] ParseIntGrid(string[] input)
        {
            var grid = new int[input.Length, input[0].Length];

            for (var row = 0; row < input.Length; row++)
            {
                for (var col = 0; col < input[0].Length; col++)
                {
                    grid[row, col] = int.Parse(input[row][col].ToString());
                }
            }

            return grid;
        }

        internal record Node
        {
            public (int row, int col) Position { get; set; }
            public int StraightStepsSoFar { get; set; }
            public char Direction { get; set; }
        }
    }
}
