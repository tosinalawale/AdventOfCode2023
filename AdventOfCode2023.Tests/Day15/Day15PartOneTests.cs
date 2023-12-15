namespace AdventOfCode2023.Tests.Day15
{
    using AdventOfCode2023.Day15;
    using FluentAssertions;

    public class Day15PartOneTests
    {
        [Test]
        public void PartOne_CalculateHash()
        {
            Day15PartOne.CalculateHash("HASH").Should().Be(52);
        }

        [Test]
        public void PartOne_CalculateResultForSimpleExample()
        {
            const string inputFileText = """
                                         rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7
                                         """;

            string[] input = inputFileText.Split(Environment.NewLine);
            Day15PartOne.CalculateResult(input).Should().Be(1320);
        }

        [Test]
        public void PartOne_CalculateResult()
        {
            string[] input = File.ReadAllLines(@"Input/input15.txt");
            int result = Day15PartOne.CalculateResult(input);
            Console.WriteLine(result);
            result.Should().Be(505459);
        }
    }
}