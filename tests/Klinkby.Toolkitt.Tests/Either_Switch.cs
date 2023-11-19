namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Either_Switch
{
    private const int Seed = 42;
  
    [Fact]
    public void Should_Switch_On_Right()
    {
        // arrange
        var dut = Either.From(Seed)
            .Bind(x => x - 2)
            .Bind(x => $"{x}");
        
        // act
        string actual = dut switch
        {
            Left<string> l => throw l.Exception!,
            Right<string> => dut,
            _ => throw new InvalidOperationException()
        };
        
        // assert
        Assert.Equal("40", actual);
    }
    
    [Fact]
    public void Should_Switch_On_Left()
    {
        // arrange
        var dut = Either.From(Seed)
            .Bind(x => x - 2)
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            .Bind(new Func<int, string>(_ => (string)(string?)default));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.
        
        // act
        var actual = dut switch
        {
            Left<string> l => l,
            _ => throw new InvalidOperationException()
        };
        
        Assert.Null(actual.Exception);
    }
}