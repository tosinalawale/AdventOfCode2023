namespace AdventOfCode2023.Tests.Day08
{
    using AdventOfCode2023.Day08;
    using FluentAssertions;

    public class Day08PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         LR
                                         
                                         11A = (11B, XXX)
                                         11B = (XXX, 11Z)
                                         11Z = (11B, XXX)
                                         22A = (22B, XXX)
                                         22B = (22C, 22C)
                                         22C = (22Z, 22Z)
                                         22Z = (22B, 22B)
                                         XXX = (XXX, XXX)
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day08PartTwo.CalculateResult(input).Should().Be(6);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input08.txt");
            double result = Day08PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(10921547990923);
        }
    }
}