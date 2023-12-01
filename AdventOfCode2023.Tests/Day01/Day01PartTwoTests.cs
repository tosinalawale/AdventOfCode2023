namespace AdventOfCode2023.Tests.Day01
{
    using AdventOfCode2023.Day01;
    using FluentAssertions;

    public class Day01PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         two1nine
                                         eightwothree
                                         abcone2threexyz
                                         xtwone3four
                                         4nineeightseven2
                                         zoneight234
                                         7pqrstsixteen
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day01PartTwo.CalculateResult(input).Should().Be(281);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input01.txt");
            int result = Day01PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(54208);
        }
    }
}