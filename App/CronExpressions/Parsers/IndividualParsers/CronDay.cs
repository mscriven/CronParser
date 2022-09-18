namespace Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers
{
    internal sealed class CronDay
    {
        public static CronDay Parse(string minuteExpression)
        {
            return new CronDay(new List<int>(CronTokenParser.Parse(minuteExpression, 1, 31)));
        }

        public IReadOnlyList<int> Days { get; }

        public CronDay(IReadOnlyList<int> days)
        {
            Days = days;
        }
    }
}