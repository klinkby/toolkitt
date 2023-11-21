namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Base64Url_Decode
{
    [Theory]
    [InlineData("", new byte[0])]
    [InlineData("AA", new byte[] {0x00})]
    [InlineData("AAE", new byte[] {0x00, 0x01})]
    [InlineData("lVO-SuE_lNJL", new byte[] {0x95, 0x53, 0xbe, 0x4a, 0xe1, 0x3f, 0x94, 0xd2, 0x4b})]
    [InlineData("TG9yZW0gaXBzdW0", new byte[] {0x4c, 0x6f, 0x72, 0x65, 0x6d, 0x20, 0x69, 0x70, 0x73, 0x75, 0x6d})] // Lorem ipsum
    public void String_Shall_Return_Bytes(string seed, byte[] expected)
    {
        // act
        var buffer = Base64Url.Decode(seed);
        // assert
        Assert.Equal(expected, buffer);
    }
}
