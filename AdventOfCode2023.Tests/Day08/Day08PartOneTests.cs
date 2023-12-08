namespace AdventOfCode2023.Tests.Day08
{
    using AdventOfCode2023.Day08;
    using FluentAssertions;

    public class Day08PartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         RL
                                         
                                         AAA = (BBB, CCC)
                                         BBB = (DDD, EEE)
                                         CCC = (ZZZ, GGG)
                                         DDD = (DDD, DDD)
                                         EEE = (EEE, EEE)
                                         GGG = (GGG, GGG)
                                         ZZZ = (ZZZ, ZZZ)
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day08PartOne.CalculateResult(input).Should().Be(2);
        }

        [Test]
        public void PartOne_CalculateResultForSimpleExample2()
        {
            const string inputFileText = """
                                         LLR
                                         
                                         AAA = (BBB, BBB)
                                         BBB = (AAA, ZZZ)
                                         ZZZ = (ZZZ, ZZZ)
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day08PartOne.CalculateResult(input).Should().Be(6);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input08.txt");
            int result = Day08PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(14429);
        }
    }
}