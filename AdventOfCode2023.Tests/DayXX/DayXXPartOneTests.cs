namespace AdventOfCode2023.Tests.DayXX
{
    using AdventOfCode2023.DayXX;
    using FluentAssertions;

    public class DayXXPartOneTests
    {
        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         Example input goes here
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            DayXXPartOne.CalculateResult(input).Should().Be(-1);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/inputXX.txt");
            int result = DayXXPartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(-1);
        }
    }
}