namespace AdventOfCode2023.Tests.Day06
{
    using AdventOfCode2023.Day06;
    using FluentAssertions;

    public class Day06PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         Time:      7  15   30
                                         Distance:  9  40  200
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day06PartOne.CalculateResult(input).Should().Be(288);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input06.txt");
            int result = Day06PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(293046);
        }
    }
}