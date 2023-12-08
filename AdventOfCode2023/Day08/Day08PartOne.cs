namespace AdventOfCode2023.Day08
{
    public class Day08PartOne
    {
        public static int CalculateResult(string[] input)
        {
            string instructions = input[0];
            Dictionary<string, (string left, string right)> network = BuildNetwork(input);

            var currentNode = "AAA";
            var numberOfSteps = 0;

            while (currentNode != "ZZZ")
            {
                foreach (char instruction in instructions)
                {
                    currentNode = instruction.Equals('R') ? network[currentNode].right : network[currentNode].left;
                    numberOfSteps++;

                    if (currentNode.Equals("ZZZ")) break;
                }
            }

            return numberOfSteps;
        }

        private static Dictionary<string, (string left, string right)> BuildNetwork(string[] input)
        {
            Dictionary<string, (string left, string right)> network = new();

            for (var i = 2; i < input.Length; i++)
            {
                string line = input[i];
                string[] lineParts = line.Split(" = ");
                string[] nodeValueParts = lineParts[1]
                    .Replace("(", string.Empty)
                    .Replace(")", string.Empty)
                    .Split(", ");
                network.Add(lineParts[0], (left: nodeValueParts[0], right: nodeValueParts[1]));
            }

            return network;
        }
    }
}
