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