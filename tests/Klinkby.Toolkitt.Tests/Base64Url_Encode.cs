namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Base64Url_Encode
{
    [Theory]
    [InlineData(default, "")]
    [InlineData(new byte[0], "")]
    [InlineData(new byte[] {0x00}, "AA")]
    [InlineData(new byte[] {0x00, 0x01}, "AAE")]
    [InlineData(new byte[] {0x95, 0x53, 0xbe, 0x4a, 0xe1, 0x3f, 0x94, 0xd2, 0x4b}, "lVO-SuE_lNJL")]
    [InlineData(new byte[] {0x4c, 0x6f, 0x72, 0x65, 0x6d, 0x20, 0x69, 0x70, 0x73, 0x75, 0x6d}, "TG9yZW0gaXBzdW0")] // Lorem ipsum
    public void Bytes_Shall_Return_String(byte[] seed, string expected)
    {
        var span = (ReadOnlySpan<byte>)seed;
        // act
        var base64Url = Base64Url.Encode(span);
        // assert
        Assert.Equal(expected, base64Url);
    }
}
