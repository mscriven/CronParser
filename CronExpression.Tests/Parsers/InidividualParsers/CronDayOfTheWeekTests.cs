using Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers;

namespace Scriven.Deliveroo.CronExpressions.Tests.Parsers.InidividualParsers
{
    [TestFixture]
    internal sealed class CronDayOfTheWeekTests
    {
        [Test]
        public void test1()
        {
            var sut = CronDayOfTheWeek.Parse("monday");
            Assert.AreEqual(0, sut.DaysOfTheWeek.Single());
        }
    }
}
