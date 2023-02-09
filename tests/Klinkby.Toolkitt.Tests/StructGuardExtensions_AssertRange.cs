namespace Klinkby.Toolkitt.Tests;

public class StructGuardExtensions_AssertRange
{

    const int RangeLo = 0;
    const int RangeHi = 10;

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(RangeLo - 1)]
    [InlineData(RangeHi + 1)]
    public void LowerOrHigher_Should_Throw(int myParameter)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            myParameter.AssertRange(RangeLo, RangeHi));
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(101)]
    public void In_Should_Throw(int myParameter)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            myParameter.AssertRange(RangeLo, RangeHi));
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(RangeLo)]
    [InlineData((RangeHi + RangeLo) / 2)] // in between
    [InlineData(RangeHi)]
    public void InRange_Should_Ok(int myParameter)
    {
        var p = myParameter.AssertRange(RangeLo, RangeHi);
        Assert.Equal(myParameter, p);
    }
}