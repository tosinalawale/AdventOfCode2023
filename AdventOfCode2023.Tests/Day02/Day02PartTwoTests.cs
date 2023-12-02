namespace AdventOfCode2023.Tests.Day02
{
    using AdventOfCode2023.Day02;
    using FluentAssertions;

    public class Day02PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                                         Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                                         Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                                         Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                                         Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day02PartTwo.CalculateResult(input).Should().Be(2286);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input02.txt");
            int result = Day02PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(78669);
        }
    }
}