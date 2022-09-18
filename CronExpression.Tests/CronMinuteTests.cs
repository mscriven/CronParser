using Scriven.Deliveroo.CronExpressions.Parsers;

namespace Scriven.Deliveroo.CronExpressions.Tests;

public class CronMinuteTests
{
    [Test]
    public void GivenAValidNumberOfMinutesReturnsMinute()
    {
        var sut = CronMinute.Parse("1");

        Assert.That(sut.Minutes[0] == 1);
        Assert.That(sut.Minutes.Count == 1);
    }

    [Test]
    public void GivenANumberSmallerThanZeroThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("-1"));
    }

    [Test]
    public void GivenANumberBiggerThanFiftyNineThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("60"));
    }

    [Test]
    public void GivenAsterixReturnAllValidMinutes()
    {
        var sut = CronMinute.Parse("*");

        CollectionAssert.AreEquivalent(Enumerable.Range(0, 60), sut.Minutes);
    }

    [Test]
    public void GivenCommaSeparatedListOfIntsReturnThoseSpecificMinutes()
    {
        var sut = CronMinute.Parse("1,4,7");
        CollectionAssert.AreEquivalent(new List<int> {1, 4, 7}, sut.Minutes);
    }

    [Test]
    public void GivenEverySyntaxReturnMinutesAtThoseTimes()
    {
        var sut = CronMinute.Parse("*/15");
        CollectionAssert.AreEquivalent(new List<int> { 0, 15, 30, 45 }, sut.Minutes);
    }

    [Test]
    public void GivenEverySyntaxWithANumberThatDoesNotFitInSixtyThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("*/38"));
    }

    [Test]
    public void GivenRangeSyntaxReturnInclusiveRangeOfNumbers()
    {
        var sut = CronMinute.Parse("5-8");
        CollectionAssert.AreEquivalent(new List<int> { 5, 6, 7, 8 }, sut.Minutes);
    }

    [Test]
    [Ignore("Not yet handled negative numbers, especially when combined with range symbol.")]
    public void GivenRangeSyntaxStartLessThanMinThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("-1-5"));
    }

    [Test]
    public void GivenRangeSyntaxStartGreaterThanMaxThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("60-5"));
    }

    [Test]
    public void GivenRangeSyntaxEndIsSmallerThanStartThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("5-4"));
    }

    [Test]
    [Ignore("Not yet handled negative numbers, especially when combined with range symbol.")]
    public void GivenRangeSyntaxEndLessThanMinThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("10--1"));
    }

    [Test]
    public void GivenRangeSyntaxEndGreaterThanMaxThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronMinute.Parse("5-60"));
    }
}
