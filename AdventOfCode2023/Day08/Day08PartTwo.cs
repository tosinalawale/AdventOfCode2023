namespace AdventOfCode2023.Day08
{ 
    public class Day08PartTwo
    {
        public static double CalculateResult(string[] input)
        {
            string instructions = input[0];
            Dictionary<string, (string left, string right)> network = BuildNetwork(input);

            List<string> startingNodes = network.Keys.Where(k => k.EndsWith("A")).ToList();
            List<double> numberOfSteps = startingNodes.Select(_ => 0d).ToList();

            for (var index = 0; index < startingNodes.Count; index++)
            {
                string node = startingNodes[index];
                while (!node.EndsWith("Z"))
                {
                    foreach (char instruction in instructions)
                    {
                        node = instruction.Equals('R') ? network[node].right : network[node].left;
                        numberOfSteps[index]++;

                        if (node.EndsWith("Z")) break;
                    }
                }
            }

            return numberOfSteps.Aggregate(LowestCommonMultiple);
        }

        private static double LowestCommonMultiple(double d1, double d2)
        {
            double absHigherNumber = Math.Max(d1, d2);
            double absLowerNumber = Math.Min(d1, d2);
            double lcm = absHigherNumber;
            while (lcm % absLowerNumber != 0)
            {
                lcm += absHigherNumber;
            }
            return lcm;
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