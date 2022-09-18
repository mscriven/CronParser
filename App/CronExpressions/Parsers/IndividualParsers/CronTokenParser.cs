namespace Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers
{
    internal sealed class CronTokenParser
    {
        public static IEnumerable<int> Parse(string timeExpression, int min, int max)
        {
            var numofNums = max - min + 1;
            if (timeExpression.Equals("*")) return Enumerable.Range(min, numofNums);

            if (timeExpression.Contains(','))
            {
                return timeExpression.Split(",").Select(s => int.Parse(s));
            }

            if (timeExpression.StartsWith("*/"))
            {
                var num = int.Parse(timeExpression.Substring(2));
                if (numofNums % num != 0) throw new InvalidOperationException($"Cannot specify frequencies because Cron is stateless. Specify a number that {max + 1} is divisible by.");
                var value = new List<int>();
                var start = min;
                while (start < max)
                {
                    value.Add(start);
                    start += num;
                }
                return value;
            }

            var potentialRange = timeExpression.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (potentialRange.Length == 2)
            {
                var start = int.Parse(potentialRange[0]);
                var end = int.Parse(potentialRange[1]);

                if (start < min || start > max) throw new InvalidOperationException($"Range must be between {min}-{max}");
                if (end < min || end > max) throw new InvalidOperationException($"Range must be between {min}-{max}");
                if (start > end) throw new InvalidOperationException("Range start must be less than or equal to range end");

                var values = new List<int>();
                while (start <= end)
                {
                    values.Add(start);
                    start += 1;
                }
                return values;
            }

            var minute = int.Parse(timeExpression);
            if (minute < min || minute > max) throw new InvalidOperationException($"Must be between {min}-{max}");
            return new List<int> { minute };
        }

        public IReadOnlyList<int> Tokens { get; }

        public CronTokenParser(IReadOnlyList<int> tokens)
        {
            Tokens = tokens;
        }
    }
}