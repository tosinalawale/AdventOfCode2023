namespace AdventOfCode2023.Tests.Day15
{
    using AdventOfCode2023.Day15;
    using FluentAssertions;

    public class Day15PartTwoTests
    {
        [Test]
        public void PartTwo_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day15PartTwo.CalculateResult(input).Should().Be(145);
        }

        [Test]
        public void PartTwo_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input15.txt");
            int result = Day15PartTwo.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(228508);
        }
    }
}