using Scriven.Deliveroo.CronExpressions.Parsers;

namespace Scriven.Deliveroo.CronExpressions.Tests;

public class CronHourTests
{
    [Test]
    public void GivenAValidNumberOfMinutesReturnsMinute()
    {
        var sut = CronHour.Parse("1");

        Assert.That(sut.Hours[0] == 1);
        Assert.That(sut.Hours.Count == 1);
    }

    [Test]
    public void GivenANumberSmallerThanZeroThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronHour.Parse("-1"));
    }

    [Test]
    public void GivenANumberBiggerThanFiftyNineThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronHour.Parse("60"));
    }

    [Test]
    public void GivenAsterixReturnAllValidMinutes()
    {
        var sut = CronHour.Parse("*");

        CollectionAssert.AreEquivalent(Enumerable.Range(0, 60), sut.Hours);
    }

    [Test]
    public void GivenCommaSeparatedListOfIntsReturnThoseSpecificMinutes()
    {
        var sut = CronHour.Parse("1,4,7");
        CollectionAssert.AreEquivalent(new List<int> {1, 4, 7}, sut.Hours);
    }

    [Test]
    public void GivenEverySyntaxReturnMinutesAtThoseTimes()
    {
        var sut = CronHour.Parse("*/15");
        CollectionAssert.AreEquivalent(new List<int> { 0, 15, 30, 45 }, sut.Hours);
    }

    [Test]
    public void GivenEverySyntaxWithANumberThatDoesNotFitInSixtyThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronHour.Parse("*/38"));
    }
}
