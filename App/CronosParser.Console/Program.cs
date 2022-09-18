using Scriven.Deliveroo.CronExpressions;

namespace CronosParser.ConsoleHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cronParser = new CronExpressionParser();
            var result = cronParser.Parse(args.Take(5).ToList());

            PrintEntry("minutes", result.Minutes);
            PrintEntry("hour", result.Hours);
            PrintEntry("day of month", result.Days);
            PrintEntry("month", result.Months);
            PrintEntry("day of week", result.DaysOfTheWeek);
            PrintEntry("command", args[5]);
        }

        private static void PrintEntry(string title, IEnumerable<int> timeTokens)
        {
            PrintEntry(title, string.Join(' ', timeTokens));
        }

        private static void PrintEntry(string title, string value)
        {
            Console.WriteLine($"{title,-14}" + value);
        }
    }
}