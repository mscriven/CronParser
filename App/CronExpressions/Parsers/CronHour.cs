namespace Scriven.Deliveroo.CronExpressions.Parsers
{
    internal sealed class CronHour
    {
        public static CronHour Parse(string hourExpression)
        {
            return new CronHour(new List<int>(CronTokenParser.Parse(hourExpression, 0, 23)));
        }

        public IReadOnlyList<int> Hours { get; }

        public CronHour(IReadOnlyList<int> minutes)
        {
            Hours = minutes;
        }
    }
}