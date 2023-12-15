namespace AdventOfCode2023.Day15

{
    public class Day15PartOne
    {
        public static int CalculateResult(string[] input)
        {
            return input.SelectMany(line => line.Split(',')).Sum(CalculateHash);
        }

        public static int CalculateHash(string inputString)
        {
            var currentValue = 0;

            foreach (char character in inputString)
            {
                currentValue += (int)character;
                currentValue *= 17;
                currentValue %= 256;
            }

            return currentValue;
        }
    }
}
