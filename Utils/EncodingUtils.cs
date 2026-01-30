namespace ProjectPP.Utils;

public static class EncodingUtils
{
    public static byte[] GetBytes<T>(this string input)
    {
        return System.Text.Encoding.UTF8.GetBytes(input);
    }
    public static string GetString(this byte[] input)
    {
        return System.Text.Encoding.UTF8.GetString(input);
    }
}
