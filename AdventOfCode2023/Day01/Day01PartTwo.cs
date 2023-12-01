namespace AdventOfCode2023.Day01
{
    public class Day01PartTwo
    {
        private static readonly Dictionary<string, char> NumberStrings = new()
        {
            { "one",'1' }, { "two", '2' }, { "three", '3' },
            { "four", '4' }, { "five", '5' }, { "six", '6' }, 
            { "seven", '7' }, { "eight", '8' }, { "nine", '9' }
        };

        public static int CalculateResult(string[] input)
        {
            return PartTwo(input);
        }

        private static int PartTwo(string[] input)
        {
            var currentSum = 0;

            foreach (string line in input)
            {
                char firstDigit = GetFirstDigit(line);
                char lastDigit = GetLastDigit(line);

                currentSum += int.Parse(new string(new []{ firstDigit, lastDigit }));
            }

            return currentSum;
        }

        private static char GetLastDigit(string line)
        {
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    return line.Last(c => char.IsDigit(c));
                }
                else if (NumberStrings.Keys.Any(k => line.Substring(0, i + 1).EndsWith(k)))
                {
                    return NumberStrings[NumberStrings.Keys.First(d => line.Substring(0, i + 1).EndsWith(d))];
                }
            }

            return '0';
        }

        private static char GetFirstDigit(string line)
        {
            for (var i = 0; i <= line.Length - 1; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    return line.First(c => char.IsDigit(c));
                }
                else if (NumberStrings.Keys.Any(k => line.Substring(i).StartsWith(k)))
                {
                    return NumberStrings[NumberStrings.Keys.First(d => line.Substring(i).StartsWith(d))];
                }
            }

            return '0';
        }
    }
}