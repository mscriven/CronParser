using System;

namespace Scriven.Deliveroo.CronExpressions.Parsers
{
    internal sealed class CronDayOfTheWeek
    {
        public static CronDayOfTheWeek Parse(string minuteExpression)
        {
            return new CronDayOfTheWeek(new List<int>(CronTokenParser.Parse(minuteExpression, 0, 6)));
        }

        public IReadOnlyList<int> DaysOfTheWeek { get; }

        public CronDayOfTheWeek(IReadOnlyList<int> days)
        {
            DaysOfTheWeek = days;
        }
    }
}