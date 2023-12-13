namespace AdventOfCode2023.Tests.Day13
{
    using AdventOfCode2023.Day13;
    using FluentAssertions;

    public class Day13PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         #.##..##.
                                         ..#.##.#.
                                         ##......#
                                         ##......#
                                         ..#.##.#.
                                         ..##..##.
                                         #.#.##.#.
                                         
                                         #...##..#
                                         #....#..#
                                         ..##..###
                                         #####.##.
                                         #####.##.
                                         ..##..###
                                         #....#..#
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day13PartTwo.CalculateResult(input).Should().Be(400);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input13.txt");
            int result = Day13PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(32854);
        }
    }
}