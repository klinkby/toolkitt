using System.Text;

namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Base64Url_Two_Ways
{
    [Theory]
    [InlineData("")]
    [InlineData("AA")]
    [InlineData("rQ")]
    [InlineData("KEU")]
    [InlineData("Wwx_")]
    [InlineData("67mVAQ")]
    [InlineData("hk85grI")]
    [InlineData("zlyINI-j")]
    [InlineData("D8kbZlqPP7g")]
    [InlineData("lVO-SuE_lNJL")]
    [InlineData("isB2MIf5UQmqFFqvqE-3vqSaQqcklTunzQBkTf3BA6N5Smm8ZDJmMM66TTafroYFYFi5AcY3-98tjDt4aw61kfR5jr99XMEHf3pvnqpJCnAiUalmNsdo5CO1rJEOFkV4AAo4fypviTi7edWird5aLUrYIQ2jcdt4vtq0j61rSFo")]
    public void Pass_Through_Encoder_Decoder(string expected)
    {
        // act
        var buffer = Base64Url.Decode(expected);
        var actual = Base64Url.Encode(buffer);
        
        // assert
        Assert.Equal(expected, actual);
    }
}
