namespace Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers
{
    internal sealed class CronMinute
    {
        public static CronMinute Parse(string minuteExpression)
        {
            return new CronMinute(new List<int>(CronTokenParser.Parse(minuteExpression, 0, 59)));
        }

        public IReadOnlyList<int> Minutes { get; }

        public CronMinute(IReadOnlyList<int> minutes)
        {
            Minutes = minutes;
        }
    }
}