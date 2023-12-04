namespace AdventOfCode2023.Tests.Day03
{
    using AdventOfCode2023.Day03;
    using FluentAssertions;

    public class Day03PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         467..114..
                                         ...*......
                                         ..35..633.
                                         ......#...
                                         617*......
                                         .....+.58.
                                         ..592.....
                                         ......755.
                                         ...$.*....
                                         .664.598..
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day03PartTwo.CalculateResult(input).Should().Be(467835);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input03.txt");
            int result = Day03PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(87287096);
        }
    }
}