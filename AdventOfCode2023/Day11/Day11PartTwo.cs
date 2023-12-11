namespace AdventOfCode2023.Day11
{
    public class Day11PartTwo
    {
        public static long CalculateResult(string[] input)
        {
            return CalculateResultWithExpansion(input, 1000000);
        }

        public static long CalculateResultWithExpansion(string[] input, int expansionFactor)
        {
            List<string> inputWithExpandedRows = new();
            List<int> rowsToBeExpanded = new();

            for (var row = 0; row < input.Length; row++)
            {
                if (!input[row].Contains('#'))
                {
                    rowsToBeExpanded.Add(row);
                }
            }

            List<int> columnsToBeExpanded = new();

            for (var col = 0; col < input[0].Length; col++)
            {
                if (input.Select(x => x[col]).All(c => c.Equals('.')))
                {
                    columnsToBeExpanded.Add(col);
                }
            }

            List<(int row, int col)> galaxies = GetGalaxies(input.ToList());
            List<long> distances = new();

            for (var i = 0; i < galaxies.Count - 1; i++)
                for (int j = i + 1; j < galaxies.Count; j++)
                    distances.Add(Distance(galaxies[i], galaxies[j], rowsToBeExpanded, columnsToBeExpanded, expansionFactor));

            return distances.Sum();
        }

        private static long Distance((int row, int col) galaxy1, (int row, int col) galaxy2, List<int> rowsToBeExpanded,
            List<int> columnsToBeExpanded, int expansionFactor)
        {
            int biggerRow = galaxy1.row > galaxy2.row ? galaxy1.row : galaxy2.row;
            int smallerRow = galaxy1.row < galaxy2.row ? galaxy1.row : galaxy2.row;
            int biggerCol = galaxy1.col > galaxy2.col ? galaxy1.col : galaxy2.col;
            int smallerCol = galaxy1.col < galaxy2.col ? galaxy1.col : galaxy2.col;

            int numberOfExpandedRowsInRange = rowsToBeExpanded.Count(x => x >= smallerRow && x <= biggerRow);
            int numberOfExpandedColumnsInRange = columnsToBeExpanded.Count(x => x >= smallerCol && x <= biggerCol);

            long distance = (biggerRow - smallerRow) - numberOfExpandedRowsInRange + numberOfExpandedRowsInRange*expansionFactor
                            + (biggerCol - smallerCol) - numberOfExpandedColumnsInRange + numberOfExpandedColumnsInRange*expansionFactor;

            return distance;
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
