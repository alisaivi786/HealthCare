namespace AM.Common.Extensions.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class EnumTypeAttribute(int startNum) : Attribute
{
    public int StartNum { get; } = startNum;
}
