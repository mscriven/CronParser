using System;

namespace Scriven.Deliveroo.CronExpressions.Parsers
{
    internal sealed class CronMonth
    {
        public static CronMonth Parse(string minuteExpression)
        {
            return new CronMonth(new List<int>(CronTokenParser.Parse(minuteExpression, 1, 12)));
        }

        public IReadOnlyList<int> Months { get; }

        public CronMonth(IReadOnlyList<int> months)
        {
            Months = months;
        }
    }
}