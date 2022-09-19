using Scriven.Deliveroo.CronExpressions.Parsers.IndividualParsers;

namespace Scriven.Deliveroo.CronExpressions.Tests;

[TestFixture]
internal sealed class CronTokenParserTests
{
    [Test]
    public void GivenAValidNumberOfMinutesReturnsMinute()
    {
        var sut = CronTokenParser.Parse("1", 0, 59).ToList();

        Assert.That(sut[0] == 1);
        Assert.That(sut.Count == 1);
    }

    [Test]
    public void GivenANumberSmallerThanZeroThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("-1", 0, 59));
    }

    [Test]
    public void GivenANumberBiggerThanFiftyNineThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("60", 0, 59));
    }

    [Test]
    public void GivenAsterixReturnAllValidMinutes()
    {
        var sut = CronTokenParser.Parse("*", 0, 59);

        CollectionAssert.AreEquivalent(Enumerable.Range(0, 60), sut);
    }

    [Test]
    public void GivenCommaSeparatedListOfIntsReturnThoseSpecificMinutes()
    {
        var sut = CronTokenParser.Parse("1,4,7", 0, 10);
        CollectionAssert.AreEquivalent(new List<int> { 1, 4, 7 }, sut);
    }

    [Test]
    public void GivenEverySyntaxReturnMinutesAtThoseTimes()
    {
        var sut = CronTokenParser.Parse("*/15", 0, 59);
        CollectionAssert.AreEquivalent(new List<int> { 0, 15, 30, 45 }, sut);
    }

    [Test]
    public void GivenEverySyntaxWithANumberThatDoesNotFitInSixtyThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("*/38", 0, 59));
    }

    [Test]
    public void GivenRangeSyntaxReturnInclusiveRangeOfNumbers()
    {
        var sut = CronTokenParser.Parse("5-8", 2, 10);
        CollectionAssert.AreEquivalent(new List<int> { 5, 6, 7, 8 }, sut);
    }

    [Test]
    public void GivenRangeSyntaxStartLessThanMinThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("1-5", 2, 59));
    }

    [Test]
    public void GivenRangeSyntaxStartGreaterThanMaxThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("60-5", 0, 59));
    }

    [Test]
    public void GivenRangeSyntaxEndIsSmallerThanStartThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("5-4", 0, 59));
    }

    [Test]
    public void GivenRangeSyntaxEndLessThanMinThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("12-9", 11, 15));
    }

    [Test]
    public void GivenRangeSyntaxEndGreaterThanMaxThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("5-60", 0, 59));
    }

    [Test]
    public void GivenRangeWithInvalidValuesThrow()
    {
        Assert.Throws<InvalidOperationException>(() => CronTokenParser.Parse("3,5,7", 0, 5));
    }
}
