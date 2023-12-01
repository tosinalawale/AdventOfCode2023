namespace AdventOfCode2023.Tests.Day01
{
    using AdventOfCode2023.Day01;
    using FluentAssertions;

    public class Day01Tests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            //var input = new[]
            //{
            //    "1abc2",
            //    "pqr3stu8vwx",
            //    "a1b2c3d4e5f",
            //    "treb7uchet"
            //};

            const string inputFileText = """
                                         1abc2
                                         pqr3stu8vwx
                                         a1b2c3d4e5f
                                         treb7uchet
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day01.CalculateResultForPartTwo(input).Should().Be(142);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input01.txt");
            int result = Day01.CalculateResultForPartOne(input);
            Console.WriteLine(result);
            result.Should().Be(54940);
        }

        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            //var input = new[]
            //{
            //    "two1nine",
            //    "eightwothree",
            //    "abcone2threexyz",
            //    "xtwone3four",
            //    "4nineeightseven2",
            //    "zoneight234",
            //    "7pqrstsixteen"
            //};

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
            Day01.CalculateResultForPartTwo(input).Should().Be(281);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input01.txt");
            int result = Day01.CalculateResultForPartTwo(input);
            Console.WriteLine(result);
            result.Should().Be(54208);
        }
    }
}