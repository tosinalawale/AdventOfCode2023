namespace AdventOfCode2023.Day11
{
    public class Day11PartOne
    {
        public static long CalculateResult(string[] input)
        {
            List<string> inputWithExpandedRows = new();

            foreach (string line in input)
            {
                inputWithExpandedRows.Add(line);

                if (!line.Contains('#'))
                {
                    inputWithExpandedRows.Add(line);
                }
            }

            List<int> columnsToBeExpanded = new();
            List<string> inputWithExpandedRowsAndColumns = new();

            for (var col = 0; col < input[0].Length; col++)
            {
                if (input.Select(x => x[col]).All(c => c.Equals('.')))
                {
                    columnsToBeExpanded.Add(col);
                }
            }

            foreach (string line in inputWithExpandedRows)
            {
                var newLine = string.Empty;

                for (var col = 0; col < line.Length; col++)
                {
                    if (columnsToBeExpanded.Contains(col))
                    {
                        newLine += '.';
                        newLine += '.';
                    }
                    else
                    {
                        newLine += line[col];
                    }
                }

                inputWithExpandedRowsAndColumns.Add(newLine);
            }

            List<(int row, int col)> galaxies = GetGalaxies(inputWithExpandedRowsAndColumns);
            List<long> distances = new();

            for (var i = 0; i < galaxies.Count - 1; i++)
            for (int j = i + 1; j < galaxies.Count; j++)
                distances.Add(Distance(galaxies[i], galaxies[j]));

            return distances.Sum();
        }

        private static long Distance((int row, int col) galaxy1, (int row, int col) galaxy2)
        {
            return Math.Abs(galaxy1.row - galaxy2.row) + Math.Abs(galaxy1.col - galaxy2.col);
        }

        private static List<(int row, int col)> GetGalaxies(List<string> input)
        {
            List<(int row, int col)> galaxies = new();

            for (var row = 0; row < input.Count; row++)
            {
                string line = input[row];
                for (var col = 0; col < line.Length; col++)
                {
                    if (line[col].Equals('#'))
                    {
                        galaxies.Add((row, col));
                    }
                }
            }

            return galaxies;
        }
    }
}
