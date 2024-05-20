namespace AM.Common.Extensions.String;

public static partial class StringExtension
{
    public static bool IsEmpty(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static bool IsEmpty(this object value)
    {
        if (value != null && !string.IsNullOrEmpty(value.ToString()))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool IsEmpty(this Guid? value)
    {
        if (value == null)
            return true;
        return IsEmpty(value.Value);
    }

    public static bool IsEmpty(this Guid value)
    {
        if (value == Guid.Empty)
            return true;
        return false;
    }
}
