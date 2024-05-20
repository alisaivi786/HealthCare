namespace AM.Common.Extensions.Enum;

public static partial class Extensions
{
    public static Dictionary<int, string> EnumToDictionary(this Type enumType)
    {
        Dictionary<int, string> dictionary = new();
        Type typeDescription = typeof(DescriptionAttribute);
        FieldInfo[] fields = enumType.GetFields();
        int sValue = 0;
        string sText = string.Empty;
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType.IsEnum)
            {
                sValue = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                object[] arr = field.GetCustomAttributes(typeDescription, true);
                if (arr.Length > 0)
                {
                    DescriptionAttribute da = (DescriptionAttribute)arr[0];
                    sText = da.Description;
                }
                else
                {
                    sText = field.Name;
                }
                dictionary.Add(sValue, sText);
            }
        }
        return dictionary;
    }
    public static string EnumToDictionaryString(this Type enumType)
    {
        List<KeyValuePair<int, string>> dictionaryList = EnumToDictionary(enumType).ToList();
        var sJson = System.Text.Json.JsonSerializer.Serialize(dictionaryList);
        return sJson;
    }
    public static string GetDescription(this System.Enum enumType)
    {
        FieldInfo? EnumInfo = enumType.GetType().GetField(enumType.ToString());
        if (EnumInfo != null)
        {
            DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])EnumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (EnumAttributes.Length > 0)
            {
                return EnumAttributes[0].Description;
            }
        }
        return enumType.ToString();
    }

    public static string GetDefaultValue(this System.Enum enumType)
    {
        FieldInfo? EnumInfo = enumType.GetType().GetField(enumType.ToString());
        if (EnumInfo != null)
        {
            DefaultValueAttribute[] EnumAttributes = (DefaultValueAttribute[])EnumInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            if (EnumAttributes.Length > 0)
            {
                if(EnumAttributes.Length != 0)
                {
                    return EnumAttributes[0].Value.ToString();
                }
            }
        }
        return enumType.ToString();
    }
    public static int? GetIntValueByEnum<T>(this object obj) where T : struct, System.Enum
    {
        if (obj == null || !System.Enum.TryParse(typeof(T), obj.ToString(), out var enumValue))
            return null;

        return Convert.ToInt32(enumValue);
    }
    //public static string GetDescriptionByEnum<T>(this object obj) where T : struct
    //{
    //    T tEnum;
    //    var isOk = System.Enum.TryParse<T>(Convert.ToString(obj), out tEnum);
    //    if (!isOk) return "unknown status";
    //    var description = (tEnum as System.Enum).GetDescription();
    //    return description;
    //}

    public static string GetDescriptionByEnum<T>(this object obj) where T : struct, System.Enum
    {
        if (obj == null || !System.Enum.TryParse(obj.ToString(), out T tEnum))
            return "unknown status";

        return GetEnumDescription(tEnum);
    }

    private static string GetEnumDescription<T>(T value) where T : struct, System.Enum
    {
        Type type = value.GetType();
        if (!type.IsEnum)
            throw new ArgumentException($"{nameof(value)} must be an enum type");

        MemberInfo[] memberInfo = type.GetMember(value.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var descriptionAttributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (descriptionAttributes != null && descriptionAttributes.Length > 0)
                return ((DescriptionAttribute)descriptionAttributes[0]).Description;
        }

        return value.ToString();
    }

    public static int GetTypeValue(this System.Enum em)
    {
        if (em == null)
            throw new ArgumentNullException(nameof(em));

        FieldInfo? enumField = em.GetType().GetField(em.ToString());
        if (enumField != null)
        {
            EnumTypeAttribute attribute = enumField.GetCustomAttribute<EnumTypeAttribute>();
            if (attribute != null)
                return attribute.StartNum;
        }
        return -1;
    }

    //public static int GetTypeValue1(this System.Enum em)
    //{
    //    int res = -1;
    //    FieldInfo? EnumInfo = em.GetType().GetField(em.ToString());
    //    if (EnumInfo != null)
    //    {
    //        EnumTypeAttribute EnumAttributes = (EnumTypeAttribute)EnumInfo.GetCustomAttribute(typeof(EnumTypeAttribute), false);

    //        res = EnumAttributes.StartNum;
    //    }
    //    return res;
    //}
}
