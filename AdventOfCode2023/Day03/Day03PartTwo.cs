namespace AdventOfCode2023.Day03
{
    public class Day03PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            var numbersDict = new Dictionary<(int, int), string>();
            var symbolsDict = new Dictionary<(int, int), string>();

            int lineLength = input[0].Length;

            ParseInput(input, ref numbersDict, ref symbolsDict);

            var numbersAdjacentToAsteriskSymbol = new Dictionary<(int, int), List<int>>();

            foreach ((int, int) numberPosition in numbersDict.Keys)
            {
                var adjacentPositions = new List<(int, int)>();

                if (numberPosition.Item1 > 0) adjacentPositions.Add((numberPosition.Item1 - 1, numberPosition.Item2));
                if (numberPosition.Item1 < lineLength) adjacentPositions.Add((numberPosition.Item1 + numbersDict[numberPosition].Length, numberPosition.Item2));
                if (numberPosition.Item2 > 0)
                {
                    for (int i = numberPosition.Item1 > 0 ? numberPosition.Item1 - 1 : numberPosition.Item1; i <= numberPosition.Item1 + numbersDict[numberPosition].Length; i++)
                    {
                        adjacentPositions.Add((i, numberPosition.Item2 - 1));
                    }
                }

                if (numberPosition.Item2 < input.Length)
                {
                    for (int i = numberPosition.Item1 > 0 ? numberPosition.Item1 - 1 : numberPosition.Item1; i <= numberPosition.Item1 + numbersDict[numberPosition].Length; i++)
                    {
                        adjacentPositions.Add((i, numberPosition.Item2 + 1));
                    }
                }

                foreach ((int, int) position in adjacentPositions)
                {
                    if (symbolsDict.ContainsKey(position) && symbolsDict[position].Equals("*"))
                    {
                        if (!numbersAdjacentToAsteriskSymbol.ContainsKey(position))
                        {
                            numbersAdjacentToAsteriskSymbol.Add(position, new());
                        }
                        numbersAdjacentToAsteriskSymbol[position].Add(int.Parse(numbersDict[numberPosition]));
                    }
                }
            }

            return numbersAdjacentToAsteriskSymbol.Values.Where(l => l.Count == 2).Sum(l => l[0] * l[1]);
        }

        private static void ParseInput(string[] input, ref Dictionary<(int, int), string> numbersDict, ref Dictionary<(int, int), string> symbolsDict)
        {
            for (var row = 0; row < input.Length; row++)
            {
                string line = input[row];
                var i = 0;
                while (i < line.Length)
                {
                    if (line[i] == '.')
                    {
                        i++;
                    }
                    else if (char.IsDigit(line[i]))
                    {
                        var numberString = line[i].ToString();
                        int iPosition = i;
                        i++;
                        while (i < line.Length && char.IsDigit(line[i]))
                        {
                            numberString += line[i];
                            i++;
                        }

                        numbersDict.Add((iPosition, row), numberString);
                    }
                    else
                    {
                        var symbolString = line[i].ToString();
                        int iPosition = i;
                        symbolsDict.Add((iPosition, row), symbolString);
                        i++;
                    }
                }
            }
        }
    }
}