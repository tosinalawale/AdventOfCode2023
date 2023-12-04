namespace AdventOfCode2023.Day04
{
    public class Day04PartOne
    {
        public static int CalculateResult(string[] input)
        {
            List<int> cardPoints = new();

            foreach (string line in input)
            {
                string[] lineParts = line.Split(": ")[1].Trim().Split(" | ");
                string[] winningNumbers = lineParts[0].Replace("  ", " ").Split(" ");
                string[] yourNumbers = lineParts[1].Replace("  ", " ").Split(" ");

                int numberOfMatches = yourNumbers.Count(n => winningNumbers.Contains(n));
                cardPoints.Add(numberOfMatches == 0 ? 0 : Convert.ToInt32(Math.Pow(2, numberOfMatches - 1)));
            }

            return cardPoints.Sum();
        }
    }
}