namespace AdventOfCode2023.Day01
{
    public class Day01PartOne
    {

        public static int CalculateResult(string[] input)
        {
            var currentSum = 0;

            foreach (string line in input)
            {
                char firstDigit = line.First(c => char.IsDigit(c));
                char lastDigit = line.Last(c => char.IsDigit(c));

                currentSum += int.Parse(new string(new[] { firstDigit, lastDigit }));
            }

            return currentSum;
        }
    }
}