namespace AdventOfCode2023.Tests.Day09
{
    using AdventOfCode2023.Day09;
    using FluentAssertions;

    public class Day09PartOneTests
    {
        [TestCase("0 3 6 9 12 15", 18)]
        [TestCase("1 3 6 10 15 21", 28)]
        [TestCase("10 13 16 21 30 45", 68)]
        public void PartOne_CalculateResultForSingleLineExamples(string inputLine, int expectedNextValue)
        {
            string inputFileText = inputLine;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day09PartOne.CalculateResult(input).Should().Be(expectedNextValue);
        }

        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         0 3 6 9 12 15
                                         1 3 6 10 15 21
                                         10 13 16 21 30 45
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day09PartOne.CalculateResult(input).Should().Be(114);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input09.txt");
            int result = Day09PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(1974913025);
        }
    }
}