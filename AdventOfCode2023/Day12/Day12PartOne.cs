namespace AdventOfCode2023.Day12
{
    public class Day12PartOne
    {
        public static int CalculateResult(string[] input)
        {
            var numOfArrangements = 0;

            foreach (string line in input)
            {
                string[] lineParts = line.Split(' ');
                string conditionRecords = lineParts[0];
                List<int> damagedSprings = lineParts[1]
                    .Split(',')
                    .Select(int.Parse)
                    .ToList();

                List<string> linePermutations = GetLinePermutations(conditionRecords);

                foreach (string linePermutation in linePermutations)
                {
                    List<int> damagedSpringsInInput = CountContiguousDamagedSprings(linePermutation);

                    if (damagedSpringsInInput.SequenceEqual<int>(damagedSprings))
                    {
                        numOfArrangements++;
                    }
                }
            }

            return numOfArrangements;
        }

        private static List<string> GetLinePermutations(string conditionRecords)
        {
            List<string> linePermutations = new();

            if (conditionRecords.Length == 0)
            {
                linePermutations.Add("");
                return linePermutations;
            }

            string suffix = conditionRecords.Length == 1 ?  string.Empty : conditionRecords[1..];

            if (conditionRecords[0] == '?')
            {
                foreach (string permutationOfRestOfLine in GetLinePermutations(suffix))
                {
                    linePermutations.Add('.' + permutationOfRestOfLine);
                    linePermutations.Add('#' + permutationOfRestOfLine);
                }
            }
            else
            {
                foreach (string permutationOfRestOfLine in GetLinePermutations(suffix))
                {
                    linePermutations.Add(conditionRecords[0] + permutationOfRestOfLine);
                }
            }

            return linePermutations;
        }

        private static List<int> CountContiguousDamagedSprings(string line)
        {
            List<int> contiguousDamagedSprings = new();

            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    var contiguousDamagedSpringsCount = 1;
                    i++;
                    while (i < line.Length && line[i] == '#')
                    {
                        contiguousDamagedSpringsCount++;
                        i++;
                    }
                    contiguousDamagedSprings.Add(contiguousDamagedSpringsCount);
                }
            }

            return contiguousDamagedSprings;
        }
    }
}
