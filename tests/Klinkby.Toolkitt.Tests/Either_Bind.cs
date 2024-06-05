namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Either_Bind
{
    private const int Seed = 42;
  
    [Fact]
    public void Value_Should_Right()
    {
        // arrange
        var dut = Either.From(Seed);
        
        // act
        var actual = dut.Bind(x => x - 2)
            .Bind(x => $"{x}");
        
        // assert
        Assert.IsType<Right<string>>(actual);
        Assert.Equal("40", actual);
    }
    
    [Fact]
    public void Null_Should_Left()
    {
        // arrange
        var dut = Either.From(Seed);
        
        // act
        var actual = dut.Bind(x => x - 2)
            .Bind(x => default(string))
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            .Bind(x => x.ToUpperInvariant())
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            .Bind<string>(_ => throw new ArithmeticException()); // not called
        
        // assert
        Assert.IsType<Left<string>>(actual);
        var left = actual as Left<string>;
        Assert.NotNull(left);
        Assert.Null(left.Exception);
        Assert.Throws<InvalidOperationException>(() => left.Value); // default
    }
    
    [Fact]
    public void Exception_Should_Left()
    {
        // arrange
        var dut = Either.From(Seed);
        
        // act
        var actual = dut.Bind(x => x - 2)
            .Bind(x => x - 2)
            .Bind(x => $"{x}")
            .Bind<string>(_ => throw new ArithmeticException())
            .Bind<string>(_ => throw new InvalidOperationException());
        
        // assert
        Assert.IsType<Left<string>>(actual);
        var left = actual as Left<string>;
        Assert.NotNull(left);
        Assert.Throws<ArithmeticException>(() => left.Value);
        Assert.IsType<ArithmeticException>(left.Exception);
    }

    [Fact]
    public void Switching()
    {
        var dut = Either.From(Seed)
            .Bind(x => x - 2)
            .Bind(x => $"{x}");

        string actual = dut switch
        {
            Left<string> l => throw l.Exception!,
            Right<string> => dut,
            _ => throw new InvalidOperationException()
        };
        Assert.Equal("40", actual);
    }
}