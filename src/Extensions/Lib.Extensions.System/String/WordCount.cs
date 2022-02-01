public static partial class Extensions
{
    public static int WordCount(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return 0;
        return str.Split(' ').Length;
    }
}
