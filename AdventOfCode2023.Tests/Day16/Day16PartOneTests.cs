namespace AdventOfCode2023.Tests.Day16
{
    using AdventOfCode2023.Day16;
    using FluentAssertions;

    public class Day16PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
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
            Day16PartOne.CalculateResult(input).Should().Be(46);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input16.txt");
            int result = Day16PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(8539);
        }
    }
}