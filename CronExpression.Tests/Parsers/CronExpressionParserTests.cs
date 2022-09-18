namespace Scriven.Deliveroo.CronExpressions
{
    [TestFixture]
    internal sealed class CronExpressionParserTests
    {
        [Test]
        public void LessThanFiveTokenThrowsException()
        {
            var sut = new CronExpressionParser();
            Assert.Throws<ArgumentException>(() => sut.Parse(new List<string> { "1", "2", "3", "4" }));
        }

        [Test]
        public void ExampleInSpec()
        {
            var sut = new CronExpressionParser();
            var expression = sut.Parse(new List<string> { "*/15", "0", "1,15", "*", "1-5" });
            CollectionAssert.AreEquivalent(new int[] { 0, 15, 30, 45 }, expression.Minutes);
            CollectionAssert.AreEquivalent(new int[] { 0 }, expression.Hours);
            CollectionAssert.AreEquivalent(new int[] { 1, 15 }, expression.Days);
            CollectionAssert.AreEquivalent(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, expression.Months);
            CollectionAssert.AreEquivalent(new int[] { 1, 2, 3, 4, 5 }, expression.DaysOfTheWeek);
        }
    }
}

