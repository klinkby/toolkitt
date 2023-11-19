namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Either_Implicit
{
    private const int Seed = 42;

    [Fact]
    public void Cast_Should_Use_Operators()
    {
        // arrange
        Either<int> dut = Seed; // using implicit factory operator

        // act
        int actual = dut; // using implicit cast operator

        // assert
        Assert.Equal(Seed, actual);
    }
}