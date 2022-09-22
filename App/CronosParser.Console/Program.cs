using Scriven.Deliveroo.CronExpressions;

namespace CronosParser.ConsoleHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) throw new ArgumentException("Must provide 1 argument");
            var splitArgs = args[0].Split(" ");
            if (splitArgs.Length != 6) throw new ArgumentException("Must provide valid cron expression and command");
            var cronParser = new CronExpressionParser();
            var result = cronParser.Parse(splitArgs.Take(5).ToList());

            PrintEntry("minutes", result.Minutes);
            PrintEntry("hour", result.Hours);
            PrintEntry("day of month", result.Days);
            PrintEntry("month", result.Months);
            PrintEntry("day of week", result.DaysOfTheWeek);
            PrintEntry("command", splitArgs[5]);


            var next5 = CombineOptions(result);
            foreach (var item in next5)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintEntry(string title, IEnumerable<int> timeTokens)
        {
            PrintEntry(title, string.Join(' ', timeTokens));
        }

        private static void PrintEntry(string title, string value)
        {
            Console.WriteLine($"{title,-14}" + value);
        }

        // Format as a string for simpler return value
        // m:dd:h:m
        private static List<DateTime> CombineOptions(ICronExpression cronExpression)
        {
            var now = DateTime.Now;

            var answer = new List<DateTime>();
            while (answer.Count < 5)
            {
                // does current minute match?
                if (cronExpression.Minutes.Contains(now.Minute)
                    && cronExpression.Hours.Contains(now.Hour)
                    && cronExpression.Days.Contains(now.Day)
                    && cronExpression.DaysOfTheWeek.Contains((int)now.DayOfWeek)
                    && cronExpression.Months.Contains(now.Month))
                {
                    // copy and create new one with only data we want
                    answer.Add(now);
                }


                now = now.AddMinutes(1);
            }
            return answer;
        }
    }
}