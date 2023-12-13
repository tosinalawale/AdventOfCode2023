namespace AdventOfCode2023.Tests.Day13
{
    using AdventOfCode2023.Day13;
    using FluentAssertions;

    public class Day13PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSinglePatternWithVerticalReflection()
        {
            const string inputFileText = """
                                         #.##..##.
                                         ..#.##.#.
                                         ##......#
                                         ##......#
                                         ..#.##.#.
                                         ..##..##.
                                         #.#.##.#.
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day13PartOne.CalculateResult(input).Should().Be(5);
        }

        [Test]
        public void PartOne_CalculateResultForSinglePatternWithHorizontalReflection()
        {
            const string inputFileText = """
                                         #...##..#
                                         #....#..#
                                         ..##..###
                                         #####.##.
                                         #####.##.
                                         ..##..###
                                         #....#..#
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day13PartOne.CalculateResult(input).Should().Be(400);
        }

        [Test]
        public void PartOne_CalculateResultForSimpleExample()
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
            Day13PartOne.CalculateResult(input).Should().Be(405);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input13.txt");
            int result = Day13PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(37025);
        }
    }
}