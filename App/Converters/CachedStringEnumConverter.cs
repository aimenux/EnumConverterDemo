using System.ComponentModel;
using System.Globalization;

namespace App.Converters;

public sealed class CachedStringEnumConverter<T> : EnumConverter where T : struct, Enum
{
    public CachedStringEnumConverter() : base(typeof(T))
    {
    }

    static CachedStringEnumConverter()
    {
        Cache.Add(typeof(T), CreateEnumDictionary<T>());
    }

    private static readonly Dictionary<Type, Dictionary<string, Enum>> Cache = new Dictionary<Type, Dictionary<string, Enum>>();

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => sourceType == typeof(string);

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string stringValue && Cache[typeof(T)].TryGetValue(stringValue, out var enumValue))
        {
            return enumValue;
        }

        return base.ConvertFrom(context, culture, value!);
    }

    private static Dictionary<string, Enum> CreateEnumDictionary<TEnumType>()
    {
        return Enum.GetValues(typeof(TEnumType)).Cast<Enum>().ToDictionary(t => t.ToEnumMember() ?? t.ToString(), t => t, StringComparer.OrdinalIgnoreCase);
    }
}