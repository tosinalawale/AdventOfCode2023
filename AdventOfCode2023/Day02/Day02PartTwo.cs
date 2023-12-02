namespace AdventOfCode2023.Day02
{
    public class Day02PartTwo
    {
        public static int CalculateResult(string[] input)
        {
            var currentSum = 0;

            foreach (string line in input)
            {
                string[] lineParts = line.Split(": ");

                List<(int, int, int)> setsInGame = GetSetsInGame(lineParts[1]);
                currentSum += setsInGame.Max(s => s.Item1) 
                              * setsInGame.Max(s => s.Item2) 
                              * setsInGame.Max(s => s.Item3);
            }

            return currentSum;
        }

        private static List<(int, int, int)> GetSetsInGame(string line)
        {
            string[] sets = line.Split(";");
            var setsInGame = new List<(int, int, int)>();

            foreach (string set in sets)
            {
                string[] setValues = set.Split(", ");
                var red = 0;
                var green = 0;
                var blue = 0;

                foreach (string setValue in setValues)
                {
                    string[] setValueParts = setValue.Trim().Split(" ");

                    if (setValueParts[1].Equals("red")) red = Convert.ToInt32(setValueParts[0]);
                    else if (setValueParts[1].Equals("green")) green = Convert.ToInt32(setValueParts[0]);
                    else if (setValueParts[1].Equals("blue")) blue = Convert.ToInt32(setValueParts[0]);
                }

                setsInGame.Add((red, green, blue));
            }

            return setsInGame;
        }
    }
}