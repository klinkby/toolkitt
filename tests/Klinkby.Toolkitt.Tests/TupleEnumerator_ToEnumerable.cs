namespace Klinkby.Toolkitt.Tests;

public class TupleEnumerator_ToEnumerable
{
    [Fact]
    public void Two_Should_Enumerate()
    {
        // arrange
        var items = new[] { 1, 2 };
        _ = items.TryToTuple(out Tuple<int, int>? dut);
        
        // act
        var actual = dut!.ToEnumerable();
        
        // assert
        Assert.Equal(items, actual);
    }
    
    [Fact]
    public void Three_Should_Enumerate()
    {
        // arrange
        var items = new[] { 1, 2, 3 };
        _ = items.TryToTuple(out Tuple<int, int, int>? dut);
        
        // act
        var actual = dut!.ToEnumerable();
        
        // assert
        Assert.Equal(items, actual);
    }

    [Fact]
    public void Four_Should_Enumerate()
    {
        // arrange
        var items = new[] { 1, 2, 3, 4 };
        _ = items.TryToTuple(out Tuple<int, int, int, int>? dut);
        
        // act
        var actual = dut!.ToEnumerable();
        
        // assert
        Assert.Equal(items, actual);
    }

    [Fact]
    public void Five_Should_Enumerate()
    {
        // arrange
        var items = new[] { 1, 2, 3, 4, 5 };
        _ = items.TryToTuple(out Tuple<int, int, int, int, int>? dut);
        
        // act
        var actual = dut!.ToEnumerable();
        
        // assert
        Assert.Equal(items, actual);
    }
    
    [Fact]
    public void Six_Should_Enumerate()
    {
        // arrange
        var items = new[] { 1, 2, 3, 4, 5, 6 };
        _ = items.TryToTuple(out Tuple<int, int, int, int, int, int>? dut);
        
        // act
        var actual = dut!.ToEnumerable();
        
        // assert
        Assert.Equal(items, actual);
    }
    
    [Fact]
    public void Seven_Should_Enumerate()
    {
        // arrange
        var items = new[] { 1, 2, 3, 4, 5, 6, 7 };
        _ = items.TryToTuple(out Tuple<int, int, int, int, int, int, int>? dut);
        
        // act
        var actual = dut!.ToEnumerable();
        
        // assert
        Assert.Equal(items, actual);
    }
}