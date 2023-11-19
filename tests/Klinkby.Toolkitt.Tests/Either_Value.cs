namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Either_Value
{
    private const int Seed = 42;
    
    [Fact]
    public void Initialized_Should_Return()
    {
        // arrange
        Either<int> dut = Either.From(Seed);
        
        // act
        int actual = dut.Value;
        
        // assert
        Assert.Equal(Seed, actual); 
    }
    
    [Fact]
    public void Default_Should_Left()
    {
        // act
        Either<string?> dut = Either.From(default(string));
        
        // assert
        Assert.IsType<Left<string?>>(dut); 
    }
}