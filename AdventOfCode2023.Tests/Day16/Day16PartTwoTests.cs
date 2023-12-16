namespace AdventOfCode2023.Tests.Day16
{
    using AdventOfCode2023.Day16;
    using FluentAssertions;

    public class Day16PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         .|...\....
                                         |.-.\.....
                                         .....|-...
                                         ........|.
                                         ..........
                                         .........\
                                         ..../.\\..
                                         .-.-/..|..
                                         .|....-|.\
                                         ..//.|....
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day16PartTwo.CalculateResult(input).Should().Be(51);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input16.txt");
            int result = Day16PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(8674);
        }
    }
}