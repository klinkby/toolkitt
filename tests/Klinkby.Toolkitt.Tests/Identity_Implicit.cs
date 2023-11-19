namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Identity_Implicit
{
    const int Seed = 42;
    
    [Fact]
    public void Cast_Should_Use_Operators()
    {
        // arrange
        Identity<int> dut1 = Seed; // implicit factory operator
        
        // act
        int actual = dut1; // implicit Value cast operator
        
        // assert
        Assert.Equal(Seed, actual);
    }
}