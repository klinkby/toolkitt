namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class ValueTupleFactory_TryToValueTuple
{
    [Fact]
    public void Two_Should_Return_True()
    {
        // arrange
        var collection = new[] { 1, 2 };
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int) actual);

        // assert
        Assert.True(result);
        Assert.Equal(collection[0], actual.Item1);
        Assert.Equal(collection[1], actual.Item2);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    public void Two_Should_Return_False(string data)
    {
        // arrange
        var collection = Generate(data);
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int) actual);
        
        // assert
        Assert.False(result);
        Assert.Equal(default, actual.Item1);
        Assert.Equal(default, actual.Item2);
    }
    
    [Fact]
    public void Three_Should_Return_True()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int) actual);

        // assert
        Assert.True(result);
        Assert.Equal(collection[0], actual.Item1);
        Assert.Equal(collection[1], actual.Item2);
        Assert.Equal(collection[2], actual.Item3);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("1,2")]
    public void Three_Should_Return_False(string data)
    {
        // arrange
        var collection = Generate(data);
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int) actual);
        
        // assert
        Assert.False(result);
        Assert.Equal(default, actual.Item1);
        Assert.Equal(default, actual.Item2);
        Assert.Equal(default, actual.Item3);
    }
    
    [Fact]
    public void Four_Should_Return_True()
    {
        // arrange
        var collection = new[] { 1, 2, 3, 4 };
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int) actual);

        // assert
        Assert.True(result);
        Assert.Equal(collection[0], actual.Item1);
        Assert.Equal(collection[1], actual.Item2);
        Assert.Equal(collection[2], actual.Item3);
        Assert.Equal(collection[3], actual.Item4);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("1,2")]
    [InlineData("1,2,3")]
    public void Four_Should_Return_False(string data)
    {
        // arrange
        var collection = Generate(data);
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int) actual);
        
        // assert
        Assert.False(result);
        Assert.Equal(default, actual.Item1);
        Assert.Equal(default, actual.Item2);
        Assert.Equal(default, actual.Item3);
        Assert.Equal(default, actual.Item4);
    }
    
    [Fact]
    public void Five_Should_Return_True()
    {
        // arrange
        var collection = new[] { 1, 2, 3, 4, 5 };
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int, int) actual);

        // assert
        Assert.True(result);
        Assert.Equal(collection[0], actual.Item1);
        Assert.Equal(collection[1], actual.Item2);
        Assert.Equal(collection[2], actual.Item3);
        Assert.Equal(collection[3], actual.Item4);
        Assert.Equal(collection[4], actual.Item5);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("1,2")]
    [InlineData("1,2,3")]
    [InlineData("1,2,3,4")]
    public void Five_Should_Return_False(string data)
    {
        // arrange
        var collection = Generate(data);
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int, int) actual);
        
        // assert
        Assert.False(result);
        Assert.Equal(default, actual.Item1);
        Assert.Equal(default, actual.Item2);
        Assert.Equal(default, actual.Item3);
        Assert.Equal(default, actual.Item4);
        Assert.Equal(default, actual.Item5);
    }
    
    [Fact]
    public void Six_Should_Return_True()
    {
        // arrange
        var collection = new[] { 1, 2, 3, 4, 5, 6 };
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int, int, int) actual);

        // assert
        Assert.True(result);
        Assert.Equal(collection[0], actual.Item1);
        Assert.Equal(collection[1], actual.Item2);
        Assert.Equal(collection[2], actual.Item3);
        Assert.Equal(collection[3], actual.Item4);
        Assert.Equal(collection[4], actual.Item5);
        Assert.Equal(collection[5], actual.Item6);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("1,2")]
    [InlineData("1,2,3")]
    [InlineData("1,2,3,4")]
    [InlineData("1,2,3,4,5")]
    public void Six_Should_Return_False(string data)
    {
        // arrange
        var collection = Generate(data);
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int, int, int) actual);
        
        // assert
        Assert.False(result);
        Assert.Equal(default, actual.Item1);
        Assert.Equal(default, actual.Item2);
        Assert.Equal(default, actual.Item3);
        Assert.Equal(default, actual.Item4);
        Assert.Equal(default, actual.Item5);
        Assert.Equal(default, actual.Item6);
    }
    
    [Fact]
    public void Seven_Should_Return_True()
    {
        // arrange
        var collection = new[] { 1, 2, 3, 4, 5, 6, 7 };
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int, int, int, int) actual);

        // assert
        Assert.True(result);
        Assert.Equal(collection[0], actual.Item1);
        Assert.Equal(collection[1], actual.Item2);
        Assert.Equal(collection[2], actual.Item3);
        Assert.Equal(collection[3], actual.Item4);
        Assert.Equal(collection[4], actual.Item5);
        Assert.Equal(collection[5], actual.Item6);
        Assert.Equal(collection[6], actual.Item7);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("1,2")]
    [InlineData("1,2,3")]
    [InlineData("1,2,3,4")]
    [InlineData("1,2,3,4,5")]
    [InlineData("1,2,3,4,5,6")]
    public void Seven_Should_Return_False(string data)
    {
        // arrange
        var collection = Generate(data);
        
        // act
        bool result = collection.TryToValueTuple<int>(out (int, int, int, int, int, int, int) actual);
        
        // assert
        Assert.False(result);
        Assert.Equal(default, actual.Item1);
        Assert.Equal(default, actual.Item2);
        Assert.Equal(default, actual.Item3);
        Assert.Equal(default, actual.Item4);
        Assert.Equal(default, actual.Item5);
        Assert.Equal(default, actual.Item6);
        Assert.Equal(default, actual.Item7);       
    }
    
    private static IEnumerable<int> Generate(string data)
    {
        var collection = 0 != data.Length ? data.Split(',').Select(int.Parse) : Array.Empty<int>();
        return collection;
    }
}