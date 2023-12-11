namespace AdventOfCode2023.Tests.Day09
{
    using AdventOfCode2023.Day09;
    using FluentAssertions;

    public class Day09PartTwoTests
    {
        [TestCase("10 13 16 21 30 45", 5 )]
        public void PartTwo_CalculateResultForSingleLineExample(string inputLine, int expectedNextValue)
        {
            string inputFileText = inputLine;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day09PartTwo.CalculateResult(input).Should().Be(expectedNextValue);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input09.txt");
            int result = Day09PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(884);
        }
    }
}