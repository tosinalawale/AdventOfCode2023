namespace AdventOfCode2023.Tests.Day05
{
    using AdventOfCode2023.Day05;
    using FluentAssertions;

    public class Day05PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         seeds: 79 14 55 13
                                         
                                         seed-to-soil map:
                                         50 98 2
                                         52 50 48
                                         
                                         soil-to-fertilizer map:
                                         0 15 37
                                         37 52 2
                                         39 0 15
                                         
                                         fertilizer-to-water map:
                                         49 53 8
                                         0 11 42
                                         42 0 7
                                         57 7 4
                                         
                                         water-to-light map:
                                         88 18 7
                                         18 25 70
                                         
                                         light-to-temperature map:
                                         45 77 23
                                         81 45 19
                                         68 64 13
                                         
                                         temperature-to-humidity map:
                                         0 69 1
                                         1 0 69
                                         
                                         humidity-to-location map:
                                         60 56 37
                                         56 93 4
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day05PartOne.CalculateResult(input).Should().Be(35);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input05.txt");
            double result = Day05PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(25174);
        }
    }
}