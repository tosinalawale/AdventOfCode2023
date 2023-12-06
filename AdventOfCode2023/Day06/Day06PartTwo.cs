namespace AdventOfCode2023.Day06
{
    public class Day06PartTwo
    {
        public static double CalculateResult(string[] input)
        {
            List<(double time, double distance)> timeDistancePairs = ParseInput(input);

            List<double> waysToWin = new();

            foreach ((double totalRaceTime, double recordDistance) in timeDistancePairs)
            {
                double buttonHoldTime = 0;
                double distanceTraveled = 0;

                while (distanceTraveled <= recordDistance)
                {
                    buttonHoldTime++;
                    distanceTraveled = buttonHoldTime * (totalRaceTime - buttonHoldTime);
                }

                double lowestButtonHoldTime = buttonHoldTime;

                buttonHoldTime = totalRaceTime;
                distanceTraveled = 0;

                while (distanceTraveled <= recordDistance)
                {
                    buttonHoldTime--;
                    distanceTraveled = buttonHoldTime * (totalRaceTime - buttonHoldTime);
                }

                double highestButtonHoldTime = buttonHoldTime;

                waysToWin.Add(highestButtonHoldTime - lowestButtonHoldTime + 1);
            }

            return waysToWin.Aggregate((x, y) => x * y);
        }

        private static List<(double time, double distance)> ParseInput(string[] input)
        {
            IEnumerable<double> times = input[0]
                .Replace("Time:", string.Empty)
                .Replace(" ", string.Empty)
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            IEnumerable<double> distances = input[1]
                .Replace("Distance:", string.Empty)
                .Replace(" ", string.Empty)
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            return times.Zip(distances).ToList();
        }
    }
}