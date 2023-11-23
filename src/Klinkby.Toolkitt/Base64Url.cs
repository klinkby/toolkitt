namespace Klinkby.Toolkitt;

/// <summary>
/// Base64Url encoding and decoding.
/// </summary>
public static class Base64Url
{
    private const int MaxStackAlloc = 256 / sizeof(char);

    /// <summary>
    /// Encode a binary blob to the URL-friendly variant of base64 (RFC 4648 §5).
    /// Alphabet is [A-Za-z0-9_-] and padding is omitted so the result can be used directly without URL-encoding,
    /// reducing size substantially.
    /// </summary>
    /// <param name="buffer">The data to encode</param>
    /// <returns>Text</returns>
    /// <exception cref="ArgumentException">Thrown if the data could not be encoded</exception>
    /// <seealso href="https://tools.ietf.org/html/rfc4648#section-5" /> 
    public static string Encode(ReadOnlySpan<byte> buffer)
    {
        // allocate chars for encoded base64url 
        var charCount = GetExactLengthInChars(buffer.Length);
        var characters = charCount <= MaxStackAlloc
            ? stackalloc char[charCount]
            : new char[charCount];
        
        // use System.Convert to encode plain base64
        if (!Convert.TryToBase64Chars(buffer, characters, out _))
            throw new ArgumentException("Failed to convert to base64", nameof(buffer));

        // strip padding and replace + and / with - and _
        var paddingChars = (buffer.Length % 3) switch
            {
                1 => 2,
                2 => 1,
                _ => 0
            };
        var base64UrlLength = charCount - paddingChars;
        for (var i = 0; i < base64UrlLength; i++)
        {
            characters[i] = characters[i] switch
            {
                '+' => '-',
                '/' => '_',
                _ => characters[i]
            };
        }

        // return as string
        var base64Url = new string(characters[..base64UrlLength]);
        return base64Url;
    }

    /// <summary>
    /// Decode a string with base64url (RFC 4648 §5) encoded data to binary blob.
    /// </summary>
    /// <param name="base64Url">The data to decode</param>
    /// <returns>Binary data</returns>
    /// <exception cref="ArgumentException">Thrown if the data could not be decoded</exception>
    /// <seealso href="https://tools.ietf.org/html/rfc4648#section-5" /> 
    public static byte[] Decode(ReadOnlySpan<char> base64Url)
    {
        // allocate buffer for decoded base64
        var stringLength = base64Url.Length;
        var paddingChars = (4 - base64Url.Length % 4) % 4;
        var paddedLength = base64Url.Length + paddingChars;
        var base64 = paddedLength <= MaxStackAlloc
            ? stackalloc char[paddedLength]
            : new char[paddedLength];
        
        // copy from source, replace - and _ with + and /
        for (var i = 0; i < stringLength; i++)
            base64[i] = base64Url[i] switch
            {
                '-' => '+',
                '_' => '/',
                _ => base64Url[i]
            };
        // add padding
        for (var i = stringLength; i < paddedLength; i++) base64[i] = '=';

        // allocate buffer for decoded base64
        var byteCount = GetExactLengthInBytes(stringLength);
        var buffer = new byte[byteCount];

        // use System.Convert to decode plain base64
        if (!Convert.TryFromBase64Chars(base64, buffer, out _))
            throw new ArgumentException("Failed to convert from base64");
        return buffer;
    }
    
    // Hat tip to https://github.com/mahalex/fasterbase64/blob/main/FasterBase64.Tests/ConvertTests.cs
    private static int GetExactLengthInChars(int lengthInBytes) 
        => lengthInBytes == 0 ? 0 : (1 + (lengthInBytes - 1) / 3) * 4;

    private static int GetExactLengthInBytes(int lengthInChars) 
        => lengthInChars == 0 ? 0 : lengthInChars * 3 / 4;
}