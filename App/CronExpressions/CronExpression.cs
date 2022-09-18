using Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers;

namespace Scriven.Deliveroo.CronExpressions
{

    internal sealed class CronExpression : ICronExpression
    {
        private readonly CronMinute mins;
        private readonly CronHour hours;
        private readonly CronDay days;
        private readonly CronMonth months;
        private readonly CronDayOfTheWeek daysOfTheWeek;

        internal CronExpression(CronMinute mins, CronHour hours, CronDay days, CronMonth months, CronDayOfTheWeek daysOfTheWeek)
        {
            this.mins = mins;
            this.hours = hours;
            this.days = days;
            this.months = months;
            this.daysOfTheWeek = daysOfTheWeek;
        }

        public IEnumerable<int> Minutes => mins.Minutes;

        public IEnumerable<int> Hours => hours.Hours;

        public IEnumerable<int> Days => days.Days;

        public IEnumerable<int> Months => months.Months;

        public IEnumerable<int> DaysOfTheWeek => daysOfTheWeek.DaysOfTheWeek;
    }
}