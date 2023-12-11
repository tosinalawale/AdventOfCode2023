namespace AdventOfCode2023.Tests.Day11
{
    using AdventOfCode2023.Day11;
    using FluentAssertions;

    public class Day11PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         ...#......
                                         .......#..
                                         #.........
                                         ..........
                                         ......#...
                                         .#........
                                         .........#
                                         ..........
                                         .......#..
                                         #...#.....
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day11PartOne.CalculateResult(input).Should().Be(374);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input11.txt");
            long result = Day11PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(9734203);
        }
    }
}