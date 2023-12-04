namespace AdventOfCode2023.Day04
{
    public class Day04PartOne
    {
        public static int CalculateResult(string[] input)
        {
            var cardPoints = new List<int>();

            foreach (string line in input)
            {
                string[] lineParts = line.Split(": ")[1].Trim().Split(" | ");
                string[] winningNumbers = lineParts[0].Replace("  ", " ").Split(" ");//.Select(int.Parse);
                string[] yourNumbers = lineParts[1].Replace("  ", " ").Split(" ");//.Select(int.Parse);

                int numberOfMatches = yourNumbers.Count(n => winningNumbers.Contains(n));
                cardPoints.Add(numberOfMatches == 0 ? 0 : Convert.ToInt32(Math.Pow(2, numberOfMatches - 1)));
            }

            return cardPoints.Sum();
        }
    }
}