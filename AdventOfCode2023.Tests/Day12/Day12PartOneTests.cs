namespace AdventOfCode2023.Tests.Day12
{
    using AdventOfCode2023.Day12;
    using FluentAssertions;

    public class Day12PartOneTests
    {
        [TestCase("???.### 1,1,3", 1)]
        [TestCase(".??..??...?##. 1,1,3", 4)]
        [TestCase("????.######..#####. 1,6,5", 4)]
        [TestCase("?###???????? 3,2,1", 10)]
        public void PartOne_CalculateResultForSingleLineExamples(string inputLine, int expectedNumOfArrangements)
        {
            string inputFileText = inputLine;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day12PartOne.CalculateResult(input).Should().Be(expectedNumOfArrangements);
        }

        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         ???.### 1,1,3
                                         .??..??...?##. 1,1,3
                                         ?#?#?#?#?#?#?#? 1,3,1,6
                                         ????.#...#... 4,1,1
                                         ????.######..#####. 1,6,5
                                         ?###???????? 3,2,1
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day12PartOne.CalculateResult(input).Should().Be(21);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input12.txt");
            int result = Day12PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(7195);
        }
    }
}