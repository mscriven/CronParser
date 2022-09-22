namespace Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers
{
    internal sealed class CronDayOfTheWeek
    {
        public static CronDayOfTheWeek Parse(string minuteExpression)
        {

            if (minuteExpression == "monday")
            {
                return new CronDayOfTheWeek(new List<int> { DayNameValues["monday"] });
            }

            var min = 0;
            var max = 6;

            // 1. Turns words into ints
            // 2. RangeParsingClass(ints)

            var potentialRange = minuteExpression.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (potentialRange.Length == 2)
            {
                if (DayNameValues.ContainsKey(potentialRange[0]) && DayNameValues.ContainsKey(potentialRange[1]))
                {

                    var start = DayNameValues[potentialRange[0]];
                    var end = DayNameValues[potentialRange[1]];

                    if (start < min || start > max) throw new InvalidOperationException($"Range must be between {min}-{max}");
                    if (end < min || end > max) throw new InvalidOperationException($"Range must be between {min}-{max}");
                    if (start > end) throw new InvalidOperationException("Range start must be less than or equal to range end");

                    var values = new List<int>();
                    while (start <= end)
                    {
                        values.Add(start);
                        start += 1;
                    }
                    return new CronDayOfTheWeek(values);
                }
            }

            return new CronDayOfTheWeek(new List<int>(CronTokenParser.Parse(minuteExpression, min, max)));
        }

        private static Dictionary<string, int> DayNameValues = new Dictionary<string, int>()
        {
            { "monday", 0},
            { "tuesday", 1 }
        };

        public IReadOnlyList<int> DaysOfTheWeek { get; }

        public CronDayOfTheWeek(IReadOnlyList<int> days)
        {
            DaysOfTheWeek = days;
        }
    }
}