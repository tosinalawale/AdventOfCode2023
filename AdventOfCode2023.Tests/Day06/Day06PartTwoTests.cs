namespace AdventOfCode2023.Tests.Day06
{
    using AdventOfCode2023.Day06;
    using FluentAssertions;

    public class Day06PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         Time:      7  15   30
                                         Distance:  9  40  200
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day06PartTwo.CalculateResult(input).Should().Be(71503);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input06.txt");
            double result = Day06PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(35150181);
        }
    }
}