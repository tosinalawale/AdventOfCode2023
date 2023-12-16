namespace AdventOfCode2023.Day16
{
    public class Day16PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            char[,] tileGrid = ParseGrid(input);
            var maxNumOfEnergisedTiles = 0;

            List<((int row, int col) beamPos, char beamDirection)> startingBeams = new();

            for (int col = 0; col < tileGrid.GetLength(1); col++) startingBeams.Add(((0, col), 'S'));
            for (int col = 0; col < tileGrid.GetLength(1); col++) startingBeams.Add(((tileGrid.GetLength(0) - 1, col), 'N'));
            for (int row = 0; row < tileGrid.GetLength(0); row++) startingBeams.Add(((row, tileGrid.GetLength(1) - 1), 'W'));
            for (int row = 0; row < tileGrid.GetLength(0); row++) startingBeams.Add(((row, 0), 'E'));

            foreach (((int row, int col) beamPos, char beamDirection) startingBeam in startingBeams)
            {
                HashSet<(int row, int col)> energised = MoveBeamThroughGrid(tileGrid, startingBeam);
                if (energised.Count > maxNumOfEnergisedTiles) maxNumOfEnergisedTiles = energised.Count;
            }

            return maxNumOfEnergisedTiles;
        }

        private static HashSet<(int row, int col)> MoveBeamThroughGrid(char[,] grid, ((int row, int col) beamPos, char beamDirection) beam)
        {
            var queue = new Queue<((int, int) beamPos, char beamDirection)>();

            int totalCols = grid.GetLength(1);
            int totalRows = grid.GetLength(0);

            queue.Enqueue(beam);

            var energised = new HashSet<(int row, int col)>();
            var beamsSeen = new HashSet<((int row, int col) beamPos, char beamDirection)>();

            while (queue.Count > 0)
            {
                ((int row, int col) beamPos, char beamDirection) = queue.Dequeue();

                energised.Add(beamPos);

                if (grid[beamPos.row, beamPos.col] == '.')
                {
                    if (beamDirection == 'E')
                    {
                        (int row, int col) newPos = (row: beamPos.row, col: beamPos.col + 1);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'E');
                        if (newPos.col < totalCols && beamsSeen.Add(newBeam))
                            queue.Enqueue(newBeam);
                    }
                    else if (beamDirection == 'S')
                    {
                        (int row, int col) newPos = (row: beamPos.row + 1, col: beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'S');
                        if (newPos.row < totalRows && beamsSeen.Add(newBeam))
                            queue.Enqueue(newBeam);
                    }
                    else if (beamDirection == 'W')
                    {
                        (int row, int col) newPos = beamPos with { col = beamPos.col - 1 };
                        ((int row, int col) newPos, char) newBeam = (newPos, 'W');
                        if (newPos.col >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'W'));
                    }
                    else if (beamDirection == 'N')
                    {
                        (int row, int col) newPos = (row: beamPos.row - 1, beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'N');
                        if (newPos.row >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'N'));
                    }
                }
                else if (grid[beamPos.row, beamPos.col] == '/')
                {
                    if (beamDirection == 'E')
                    {
                        (int row, int col) newPos = (row: beamPos.row - 1, col: beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'N');
                        if (newPos.row >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'N'));
                    }
                    else if (beamDirection == 'S')
                    {
                        (int row, int col) newPos = (row: beamPos.row, col: beamPos.col - 1);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'W');
                        if (newPos.col >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'W'));
                    }
                    else if (beamDirection == 'W')
                    {
                        (int row, int col) newPos = (row: beamPos.row + 1, col: beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'S');
                        if (newPos.row < totalRows && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'S'));
                    }
                    else if (beamDirection == 'N')
                    {
                        (int row, int col) newPos = (row: beamPos.row, col: beamPos.col + 1);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'E');
                        if (newPos.col < totalCols && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'E'));
                    }
                }
                else if (grid[beamPos.row, beamPos.col] == '\\')
                {
                    if (beamDirection == 'E')
                    {
                        (int row, int col) newPos = (row: beamPos.row + 1, col: beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'S');
                        if (newPos.row < totalRows && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'S'));
                    }
                    else if (beamDirection == 'S')
                    {
                        (int row, int col) newPos = (row: beamPos.row, col: beamPos.col + 1);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'E');
                        if (newPos.col < totalCols && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'E'));
                    }
                    else if (beamDirection == 'W')
                    {
                        (int row, int col) newPos = (row: beamPos.row - 1, col: beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'N');
                        if (newPos.row >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'N'));
                    }
                    else if (beamDirection == 'N')
                    {
                        (int row, int col) newPos = (row: beamPos.row, col: beamPos.col - 1);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'W');
                        if (newPos.col >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'W'));
                    }
                }
                else if (grid[beamPos.row, beamPos.col] == '|')
                {
                    if (beamDirection == 'E')
                    {
                        (int row, int col) newPos1 = (row: beamPos.row - 1, col: beamPos.col);
                        ((int row, int col) newPos1, char) newBeam1 = (newPos1, 'N');
                        (int row, int col) newPos2 = (row: beamPos.row + 1, col: beamPos.col);
                        ((int row, int col) newPos2, char) newBeam2 = (newPos2, 'S');
                        if (newPos1.row >= 0 && beamsSeen.Add(newBeam1))
                            queue.Enqueue((newPos1, 'N'));
                        if (newPos2.row < totalRows && beamsSeen.Add(newBeam2))
                            queue.Enqueue((newPos2, 'S'));
                    }
                    else if (beamDirection == 'S')
                    {
                        (int row, int col) newPos = (row: beamPos.row + 1, col: beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'S');
                        if (newPos.row < totalRows && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'S'));
                    }
                    else if (beamDirection == 'W')
                    {
                        (int row, int col) newPos1 = (row: beamPos.row - 1, col: beamPos.col);
                        ((int row, int col) newPos1, char) newBeam1 = (newPos1, 'N');
                        (int row, int col) newPos2 = (row: beamPos.row + 1, col: beamPos.col);
                        ((int row, int col) newPos2, char) newBeam2 = (newPos2, 'S');
                        if (newPos1.row >= 0 && beamsSeen.Add(newBeam1))
                            queue.Enqueue((newPos1, 'N'));
                        if (newPos2.row < totalRows && beamsSeen.Add(newBeam2))
                            queue.Enqueue((newPos2, 'S'));
                    }
                    else if (beamDirection == 'N')
                    {
                        (int row, int col) newPos = (row: beamPos.row - 1, col: beamPos.col);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'N');
                        if (newPos.row >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'N'));
                    }
                }
                else if (grid[beamPos.row, beamPos.col] == '-')
                {
                    if (beamDirection == 'E')
                    {
                        (int row, int col) newPos = (row: beamPos.row, col: beamPos.col + 1);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'E');
                        if (newPos.col < totalCols && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'E'));
                    }
                    else if (beamDirection == 'S')
                    {
                        (int row, int col) newPos1 = (row: beamPos.row, col: beamPos.col - 1);
                        ((int row, int col) newPos1, char) newBeam1 = (newPos1, 'W');
                        (int row, int col) newPos2 = (row: beamPos.row, col: beamPos.col + 1);
                        ((int row, int col) newPos2, char) newBeam2 = (newPos2, 'E');
                        if (newPos1.col >= 0 && beamsSeen.Add(newBeam1))
                            queue.Enqueue((newPos1, 'W'));
                        if (newPos2.col < totalCols && beamsSeen.Add(newBeam2))
                            queue.Enqueue((newPos2, 'E'));
                    }
                    else if (beamDirection == 'W')
                    {
                        (int row, int col) newPos = (beamPos.row, col: beamPos.col - 1);
                        ((int row, int col) newPos, char) newBeam = (newPos, 'W');
                        if (newPos.col >= 0 && beamsSeen.Add(newBeam))
                            queue.Enqueue((newPos, 'W'));
                    }
                    else if (beamDirection == 'N')
                    {
                        (int row, int col) newPos1 = (row: beamPos.row, col: beamPos.col - 1);
                        ((int row, int col) newPos1, char) newBeam1 = (newPos1, 'W');
                        (int row, int col) newPos2 = (row: beamPos.row, col: beamPos.col + 1);
                        ((int row, int col) newPos2, char) newBeam2 = (newPos2, 'E');
                        if (newPos1.col >= 0 && beamsSeen.Add(newBeam1))
                            queue.Enqueue((newPos1, 'W'));
                        if (newPos2.col < totalCols && beamsSeen.Add(newBeam2))
                            queue.Enqueue((newPos2, 'E'));
                    }
                }
            }

            return energised;
        }

        private static char[,] ParseGrid(string[] input)
        {
            var grid = new char[input.Length, input[0].Length];

            for (var row = 0; row < input.Length; row++)
            {
                for (var col = 0; col < input[0].Length; col++)
                {
                    grid[row, col] = input[row][col];
                }
            }

            return grid;
        }
    }
}
