namespace AdventOfCode2023.Day06
{
    public class Day06PartOne
    {
        public static int CalculateResult(string[] input)
        {
            List<(int time, int distance)> timeDistancePairs = ParseInput(input);

            List<int> waysToWin = new();

            foreach ((int totalRaceTime, int recordDistance) in timeDistancePairs)
            {
                var buttonHoldTime = 0;
                var distanceTraveled = 0;
                
                while (distanceTraveled <= recordDistance)
                {
                    buttonHoldTime++;
                    distanceTraveled = buttonHoldTime * (totalRaceTime - buttonHoldTime);
                }

                int lowestButtonHoldTime = buttonHoldTime;

                buttonHoldTime = totalRaceTime;
                distanceTraveled = 0;

                while (distanceTraveled <= recordDistance)
                {
                    buttonHoldTime--;
                    distanceTraveled = buttonHoldTime * (totalRaceTime - buttonHoldTime);
                }

                int highestButtonHoldTime = buttonHoldTime;

                waysToWin.Add(highestButtonHoldTime - lowestButtonHoldTime + 1);
            }

            return waysToWin.Aggregate((x, y) => x * y);
        }

        private static List<(int time, int distance)> ParseInput(string[] input)
        {
            IEnumerable<int> times = input[0]
                .Replace("Time:", string.Empty)
                .Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            IEnumerable<int> distances = input[1]
                .Replace("Distance:", string.Empty)
                .Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            return times.Zip(distances).ToList();
        }
    }
}
