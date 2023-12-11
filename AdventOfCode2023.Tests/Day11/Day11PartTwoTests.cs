namespace AdventOfCode2023.Tests.Day11
{
    using AdventOfCode2023.Day11;
    using FluentAssertions;

    public class Day11PartTwoTests
    {
        [TestCase(10, 1030)]
        [TestCase(100, 8410)]
        public void PartTwo_CalculateResultForSimpleExample(int expansionFactor, int expectedResult)
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
            Day11PartTwo.CalculateResultWithExpansion(input, expansionFactor).Should().Be(expectedResult);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input11.txt");
            long result = Day11PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(568914596391);
        }
    }
}