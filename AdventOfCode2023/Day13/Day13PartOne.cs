namespace AdventOfCode2023.Day13
{
    public class Day13PartOne
    {
        public static int CalculateResult(string[] input)
        {
            var summary = 0;

            var currentRow = 0;
            while (currentRow < input.Length)
            {
                (List<string> nextPattern, int nextRow) = GetNextPattern(input, currentRow);

                char[,] currentPattern = ParsePattern(nextPattern);

                int findHorizontalReflectionPoint = FindHorizontalReflectionPoint(currentPattern);

                if (findHorizontalReflectionPoint != -1)
                {
                    summary += 100 * findHorizontalReflectionPoint;
                }

                else
                {
                    int verticalReflectionPoint = FindVerticalReflectionPoint(currentPattern);

                    if (verticalReflectionPoint != -1)
                    {
                        summary += verticalReflectionPoint;
                    }
                }

                currentRow = nextRow;
            }

            return summary;
        }

        private static int FindHorizontalReflectionPoint(char[,] currentPattern)
        {
            int totalRows = currentPattern.GetLength(0);
            int totalCols = currentPattern.GetLength(1);

            for (var row = 0; row < totalRows - 1; row++)
            {
                int mirrorLowerOffset = row;
                int mirrorUpperOffset = row + 1;

                var isHorizontalReflection = true;

                while (mirrorLowerOffset >= 0 && mirrorUpperOffset <= totalRows - 1)
                {
                    string lowerRow = string.Join(
                        string.Empty, 
                        Enumerable.Range(0, totalCols).Select(x => currentPattern[mirrorLowerOffset, x]));

                    string upperRow = string.Join(
                        string.Empty,
                        Enumerable.Range(0, totalCols).Select(x => currentPattern[mirrorUpperOffset, x]));

                    if (lowerRow.Equals(upperRow))
                    {
                        mirrorLowerOffset--;
                        mirrorUpperOffset++;
                    }
                    else
                    {
                        isHorizontalReflection = false;
                        break;
                    }
                }

                if (isHorizontalReflection)
                {
                    return row + 1;
                }
            }

            return -1;
        }

        private static int FindVerticalReflectionPoint(char[,] currentPattern)
        {
            int totalRows = currentPattern.GetLength(0);
            int totalCols = currentPattern.GetLength(1);

            for (var col = 0; col < totalCols - 1; col++)
            {
                int mirrorLowerOffset = col;
                int mirrorUpperOffset = col + 1;

                var isVerticalReflection = true;

                while (mirrorLowerOffset >= 0 && mirrorUpperOffset <= totalCols - 1)
                {
                    string lowerCol = string.Join(
                        string.Empty, 
                        Enumerable.Range(0, totalRows).Select(x => currentPattern[x, mirrorLowerOffset]));

                    string upperCol = string.Join(
                        string.Empty,
                        Enumerable.Range(0, totalRows).Select(x => currentPattern[x, mirrorUpperOffset]));

                    if (lowerCol.Equals(upperCol))
                    {
                        mirrorLowerOffset--;
                        mirrorUpperOffset++;
                    }
                    else
                    {
                        isVerticalReflection = false;
                        break;
                    }
                }

                if (isVerticalReflection)
                {
                    return col + 1;
                }
            }

            return -1;
        }

        private static char[,] ParsePattern(List<string> nextPattern)
        {
            var pattern = new char[nextPattern.Count, nextPattern[0].Length];

            for (var row = 0; row < nextPattern.Count; row++)
            {
                for (var col = 0; col < nextPattern[0].Length; col++)
                {
                    pattern[row, col] = nextPattern[row][col];
                }
            }

            return pattern;
        }

        private static (List<string> GetNextPattern, int nextRow) GetNextPattern(string[] input, int startingRow)
        {
            int currentRow = startingRow;
            while (currentRow < input.Length - 1)
            {
                currentRow++;
                if (string.IsNullOrWhiteSpace(input[currentRow]))
                {
                    return (input[startingRow..currentRow].ToList(), currentRow + 1);
                }
            }

            return (input[startingRow..].ToList(), currentRow + 1);
        }
    }
}
