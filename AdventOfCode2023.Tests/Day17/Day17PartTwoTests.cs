namespace AdventOfCode2023.Tests.Day17
{
    using AdventOfCode2023.Day17;
    using FluentAssertions;

    public class Day17PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         2413432311323
                                         3215453535623
                                         3255245654254
                                         3446585845452
                                         4546657867536
                                         1438598798454
                                         4457876987766
                                         3637877979653
                                         4654967986887
                                         4564679986453
                                         1224686865563
                                         2546548887735
                                         4322674655533
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day17PartTwo.CalculateResult(input).Should().Be(94);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input17.txt");
            int result = Day17PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(1010);
        }
    }
}