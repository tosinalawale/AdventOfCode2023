namespace AdventOfCode2023.Day01
{
    public class Day01
    {
        private static readonly Dictionary<string, char> NumberStrings = new()
        {
            { "one",'1' }, { "two", '2' }, { "three", '3' },
            { "four", '4' }, { "five", '5' }, { "six", '6' }, 
            { "seven", '7' }, { "eight", '8' }, { "nine", '9' }
        };

        public static int CalculateResultForPartOne(string[] input)
        {
            return PartOne(input);
        }

        private static int PartTwo(string[] input)
        {
            var currentSum = 0;

            foreach (string line in input)
            {

                var firstDigit = '1';
                var lastDigit = '1';

                for (var i = 0; i <= line.Length - 1; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        firstDigit = line.First(c => char.IsDigit(c));
                        break;
                    }
                    else if (NumberStrings.Keys.Any(k => line.Substring(i).StartsWith(k)))
                    {
                        firstDigit = NumberStrings[NumberStrings.Keys.First(d => line.Substring(i).StartsWith(d))];
                        break;
                    }
                }

                for (int i = line.Length -1 ; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        lastDigit = line.Last(c => char.IsDigit(c));
                        break;
                    }
                    else if (NumberStrings.Keys.Any(k => line.Substring(0, i + 1).EndsWith(k)))
                    {
                        lastDigit = NumberStrings[NumberStrings.Keys.First(d => line.Substring(0, i + 1).EndsWith(d))];
                        break;
                    }
                }


                currentSum += int.Parse(new string(new []{ firstDigit, lastDigit }));
            }

            return currentSum;
        }

        public static int CalculateResultForPartTwo(string[] input)
        {
            return PartTwo(input);
        }

        private static int PartOne(string[] input)
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