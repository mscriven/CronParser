using Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers;
namespace Scriven.Deliveroo.CronExpressions
{
    public sealed class CronExpressionParser
    {
        public ICronExpression Parse(IList<string> cronTokens)
        {
            if (cronTokens.Count() != 5)
            {
                throw new ArgumentException("cron expression does not contain 5 tokens. Invalid format.");
            }

            return new CronExpression(
                CronMinute.Parse(cronTokens[0]),
                CronHour.Parse(cronTokens[1]),
                CronDay.Parse(cronTokens[2]),
                CronMonth.Parse(cronTokens[3]),
                CronDayOfTheWeek.Parse(cronTokens[4]));
        }
    }
}

