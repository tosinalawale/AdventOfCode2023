namespace AdventOfCode2023.Tests.Day01
{
    using AdventOfCode2023.Day01;
    using FluentAssertions;

    public class Day01PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         1abc2
                                         pqr3stu8vwx
                                         a1b2c3d4e5f
                                         treb7uchet
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day01PartOne.CalculateResult(input).Should().Be(142);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input01.txt");
            int result = Day01PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(54940);
        }
    }
}