namespace AdventOfCode2023.Tests.DayXX
{
    using AdventOfCode2023.DayXX;
    using FluentAssertions;

    public class DayXXPartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         Example input goes here
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            DayXXPartTwo.CalculateResult(input).Should().Be(-1);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/inputXX.txt");
            int result = DayXXPartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(-1);
        }
    }
}