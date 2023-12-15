namespace AdventOfCode2023.Day15
{
    public class Day15PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            List<List<(string label, int focalLength)>> boxes = Enumerable.Range(0, 256)
                .Select(x => new List<(string label, int focalLength)>()).ToList();

            foreach (string line in input)
            {
                string[] lineParts = line.Split(',');

                foreach (string part in lineParts)
                {
                    bool containsEqualSymbol = char.IsDigit(part[^1]);
                    string label = containsEqualSymbol ? part[0..^2] : part[0..^1];
                    int hash = CalculateHash(label);

                    if (containsEqualSymbol)
                    {
                        int focalLength = int.Parse(part[^1].ToString());

                        if (boxes[hash].All(l => l.label != label))
                        {
                            boxes[hash].Add((label, focalLength));
                        }
                        else
                        {
                            int index = boxes[hash].FindIndex(l => l.label == label);
                            boxes[hash][index] = (label, focalLength);
                        }
                    }
                    else
                    {
                        if (boxes[hash].Any(l => l.label == label))
                        {
                            boxes[hash] = boxes[hash].Where(l => l.label != label).ToList();
                        }
                    }
                }
            }

            var sum = 0;
            for (var boxNum = 0; boxNum < boxes.Count; boxNum++)
            {
                List<(string label, int focalLength)>? box = boxes[boxNum];
                for (var slotNum = 0; slotNum < box.Count; slotNum++)
                {
                    (_, int focalLength) = box[slotNum];
                    sum += (1 + boxNum) * (1 + slotNum) * focalLength;
                }
            }

            return sum;
        }

        public static int CalculateHash(string inputString)
        {
            var currentValue = 0;

            foreach (char character in inputString)
            {
                currentValue += (int)character;
                currentValue *= 17;
                currentValue %= 256;
            }

            return currentValue;
        }
    }
}