namespace AdventOfCode2023.Day07
{
    public class Day07PartOne
    {
        public static double CalculateResult(string[] input)
        {
            List<(string hand, double bid)> handsAndBids = ParseInput(input);

            handsAndBids.Sort(Comparison);

            double winnings = 0;

            for (int i = 0; i < handsAndBids.Count; i++)
            {
                winnings += handsAndBids[i].bid* (i+1);
            }

            return winnings;

        }

        private static int Comparison((string hand, double bid) x, (string hand, double bid) y)
        {
            if ((int)GetHandType(x.hand) < (int)GetHandType(y.hand))
                return 1;
            else if ((int)GetHandType(x.hand) > (int)GetHandType(y.hand))
                return -1;
            else
            {
                for (int i = 0; i < x.hand.Length; i++)
                {
                    if (x.hand[i] == y.hand[i])
                        continue;
                    else return (int)ToCard(x.hand[i]) < (int)ToCard(y.hand[i]) ? 1 : -1;
                }
            }

            return 0;
        }

        private static Card ToCard(char c)
        {
            if (char.IsDigit(c))
                return Enum.Parse<Card>($"_{c}");
            else
                return Enum.Parse<Card>(c.ToString());
        }

        private static List<(string hand, double bid)> ParseInput(string[] input)
        {
            var inputParts = input.Select(l => l.Split(" "));
            return inputParts.Select(a => (hand: a[0].ToString(), bid: double.Parse(a[1].ToString()))).ToList();
        }

        private static HandType GetHandType(string hand)
        {
            if (hand.Distinct().Count() == 1)
                return HandType.FiveOfAKind;
            if (hand.Count(c => c.Equals(hand.First())) == 4 || hand.Count(c => c.Equals(hand.Last())) == 4)
                return HandType.FourOfAKind;
            if (hand.Distinct().Count() == 2)
                return HandType.FullHouse;
            if (hand.Distinct().Count() == 3 && hand.Any(c => hand.Count(cd => cd.Equals(c)) == 3))
                return HandType.ThreeOfAKind;
            if (hand.Distinct().Count() == 3)
                return HandType.TwoPair;
            if (hand.Distinct().Count() == 4)
                return HandType.OnePair;
            if (hand.Distinct().Count() == 5)
                return HandType.HighCard;
            throw new Exception("Invalid hand type");
        }
    }

    //internal enum HandType
    //{
    //    FiveOfAKind,
    //    FourOfAKind,
    //    FullHouse,
    //    ThreeOfAKind,
    //    TwoPair,
    //    OnePair,
    //    HighCard
    //}

    internal enum Card
    {
        A, K, Q, J, T, _9, _8, _7, _6, _5, _4, _3, _2
    }
}
