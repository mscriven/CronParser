namespace Scriven.Deliveroo.CronExpressions
{
    public interface ICronExpression
    {
        IEnumerable<int> Minutes { get; }
        IEnumerable<int> Hours { get; }
        IEnumerable<int> Days { get; }
        IEnumerable<int> Months { get; }
        IEnumerable<int> DaysOfTheWeek { get; }
    }
}