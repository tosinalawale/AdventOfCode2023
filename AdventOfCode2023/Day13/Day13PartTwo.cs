namespace AdventOfCode2023.Day13
{
    public class Day13PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            var summary = 0;

            var currentRow = 0;
            while (currentRow < input.Length)
            {
                (List<string> nextPattern, int nextRow) = GetNextPattern(input, currentRow);

                char[,] currentPattern = ParsePattern(nextPattern);

                List<int> horizontalReflectionPoints = FindHorizontalReflectionPoints(currentPattern);
                
                (int point, bool isHorizontal) newReflectionPoint = (-1, true);

                if (horizontalReflectionPoints.Count != 0)
                {
                    newReflectionPoint = FindNewReflectionPoint(currentPattern, horizontalReflectionPoints[0], isHorizontal: true);
                }
                else
                {
                    List<int> verticalReflectionPoints = FindVerticalReflectionPoints(currentPattern);

                    if (verticalReflectionPoints.Count != 0)
                    {
                        newReflectionPoint = FindNewReflectionPoint(currentPattern, verticalReflectionPoints[0], isHorizontal: false);
                    }
                }

                if (newReflectionPoint.point != -1)
                {
                    summary += newReflectionPoint.isHorizontal ? 100 * newReflectionPoint.point : newReflectionPoint.point; 
                }

                currentRow = nextRow;
            }

            return summary;
        }

        private static (int point, bool isHorizontal) FindNewReflectionPoint(char[,] currentPattern, int oldReflectionPoint, bool isHorizontal)
        {
            for (var row = 0; row < currentPattern.GetLength(0); row++)
            {
                for (var col = 0; col < currentPattern.GetLength(1); col++)
                {
                    var fixedPattern = currentPattern.Clone() as char[,];
                    fixedPattern![row, col] = fixedPattern[row, col].Equals('.') ? '#' : '.';

                    List<int> horizontalReflectionPoints = FindHorizontalReflectionPoints(fixedPattern);

                    int newHorizontalReflectionPoint = horizontalReflectionPoints
                        .FirstOrDefault(x => x != oldReflectionPoint || !isHorizontal);

                    if (newHorizontalReflectionPoint != 0)
                    {
                        return (newHorizontalReflectionPoint, true);
                    }

                    List<int> verticalReflectionPoints = FindVerticalReflectionPoints(fixedPattern);

                    int newVerticalReflectionPoint = verticalReflectionPoints
                        .FirstOrDefault(x => x != oldReflectionPoint || isHorizontal);

                    if (newVerticalReflectionPoint != 0)
                    {
                        return (newVerticalReflectionPoint, false);
                    }
                }
            }

            return (-1, true);
        }

        private static List<int> FindHorizontalReflectionPoints(char[,] currentPattern)
        {
            List<int> reflectionPoints = new();

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
                    reflectionPoints.Add(row + 1);
                }
            }

            return reflectionPoints;
        }

        private static List<int> FindVerticalReflectionPoints(char[,] currentPattern)
        {
            List<int> reflectionPoints = new();

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
                    reflectionPoints.Add(col + 1);
                }
            }

            return reflectionPoints;
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
