namespace AdventOfCode2023.Day05
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day05PartOne
    {
        public static double CalculateResult(string[] input)
        {
            var seeds = input[0].Replace("seeds: ", string.Empty).Split(" ").Select(double.Parse);

            List<string> seedToSoilMappings = new();
            List<string> soilToFertilizerMappings = new();
            List<string> fertilizerToWaterMappings = new();
            List<string> waterToLightMappings = new();
            List<string> lightToTemperatureMappings = new();
            List<string> temperatureToHumidityMappings = new();
            List<string> humidityToLocationMappings = new();

            int i = 3;

            while (!string.IsNullOrWhiteSpace(input[i]))
            {
                seedToSoilMappings.Add(input[i]);
                i++;
            }

            i += 2;

            while (!string.IsNullOrWhiteSpace(input[i]))
            {
                soilToFertilizerMappings.Add(input[i]);
                i++;
            }

            i += 2;

            while (!string.IsNullOrWhiteSpace(input[i]))
            {
                fertilizerToWaterMappings.Add(input[i]);
                i++;
            }

            i += 2;

            while (!string.IsNullOrWhiteSpace(input[i]))
            {
                waterToLightMappings.Add(input[i]);
                i++;
            }

            i += 2;

            while (!string.IsNullOrWhiteSpace(input[i]))
            {
                lightToTemperatureMappings.Add(input[i]);
                i++;
            }

            i += 2;

            while (!string.IsNullOrWhiteSpace(input[i]))
            {
                temperatureToHumidityMappings.Add(input[i]);
                i++;
            }

            i += 2;

            while (i < input.Length)
            {
                humidityToLocationMappings.Add(input[i]);
                i++;
            }

            List<double> soils = InputToOutput(seeds, seedToSoilMappings);
            List<double> fertilizers = InputToOutput(soils, soilToFertilizerMappings);
            List<double> waters = InputToOutput(fertilizers, fertilizerToWaterMappings);
            List<double> lights = InputToOutput(waters, waterToLightMappings);
            List<double> temperatures = InputToOutput(lights, lightToTemperatureMappings);
            List<double> humidities = InputToOutput(temperatures, temperatureToHumidityMappings);
            List<double> locations = InputToOutput(humidities, humidityToLocationMappings);


            //Dictionary<double, double> seedToSoilMap = GetSeedToSoilMap(input);

            return locations.Min();
        }

        private static List<double> InputToOutput(IEnumerable<double> inputs, List<string> mappings)
        {
            List<double> outputs = new();

            var ranges = mappings.Select(m => m.Split(" ").Select(double.Parse).ToList()).ToList();
            var sourceRanges = ranges.Select(r => (start: r[1], length: r[2], targetStart: r[0])).ToList();

            foreach (double input in inputs)
            {
                (double start, double length, double targetStart)? matchingRow = sourceRanges
                    .FirstOrDefault(r => input >= r.start && input < r.start + r.length);

                if (matchingRow is not null)
                {
                    outputs.Add(matchingRow.Value.targetStart + input - matchingRow.Value.start);
                }

            }

            return outputs;
        }
    }
}
