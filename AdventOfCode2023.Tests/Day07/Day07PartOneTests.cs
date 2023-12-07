namespace AdventOfCode2023.Tests.Day07
{
    using AdventOfCode2023.Day07;
    using FluentAssertions;

    public class Day07PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         32T3K 765
                                         T55J5 684
                                         KK677 28
                                         KTJJT 220
                                         QQQJA 483
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day07PartOne.CalculateResult(input).Should().Be(6440);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input07.txt");
            double result = Day07PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(-1);
        }
    }
}