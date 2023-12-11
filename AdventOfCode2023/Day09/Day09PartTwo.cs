namespace AdventOfCode2023.Day09
{
    public class Day09PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            var sum = 0;

            foreach (string line in input)
            {
                var numberSequence = line.Split(' ').Select(int.Parse).ToList();
                
                List<int> previousDifferences = numberSequence.Select(x => x).ToList();
                List<int> firstValueAtEachLevel = new() { numberSequence[0] };

                while (previousDifferences.Any(x => x != 0))
                {
                    List<int> differences = new();
                    for (var i = 0; i < previousDifferences.Count - 1; i++)
                    {
                        differences.Add(previousDifferences[i + 1] - previousDifferences[i]);
                    }

                    firstValueAtEachLevel.Add(differences[0]);
                    previousDifferences = differences;
                }

                List<int> currentValueAtEachLevel = firstValueAtEachLevel.Select(x => x).ToList();

                for (int i = currentValueAtEachLevel.Count - 2; i >= 0; i--)
                {
                    currentValueAtEachLevel[i] -= currentValueAtEachLevel[i + 1];
                }

                sum += currentValueAtEachLevel[0];
            }

            return sum;
        }
    }
}
