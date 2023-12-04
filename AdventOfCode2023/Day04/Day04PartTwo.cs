namespace AdventOfCode2023.Day04
{
    public class Day04PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            Dictionary<int, int> cardMatches = new();

            for (var i = 0; i < input.Length; i++)
            {
                string line = input[i];
                string[] lineParts = line.Split(": ")[1].Trim().Split(" | ");
                string[] winningNumbers = lineParts[0].Replace("  ", " ").Split(" ");
                string[] yourNumbers = lineParts[1].Replace("  ", " ").Split(" ");

                int numberOfMatches = yourNumbers.Count(n => winningNumbers.Contains(n));
                cardMatches.Add(i + 1, numberOfMatches);
            }

            Dictionary<int, int> cardCopies = cardMatches.Keys.ToDictionary(k => k, k => 1);

            for (var i = 1; i <= cardCopies.Keys.Count; i++)
            {
                for (int j = i+1; j <= cardCopies.Keys.Count && j <= i + cardMatches[i]; j++)
                {
                    cardCopies[j] += cardCopies[i];
                }
            }

            return cardCopies.Values.Sum();
        }
    }
}