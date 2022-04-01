using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace App.Converters;

public sealed class StringEnumConverter<T> : EnumConverter
{
    public StringEnumConverter() : base(typeof(T))
    {
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => sourceType == typeof(string);

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string enumValue)
        {
            foreach (var (field, attribute) in GetFields())
            {
                if (attribute != null && string.Equals(attribute.Value, enumValue, StringComparison.OrdinalIgnoreCase))
                {
                    return field.GetValue(null);
                }
            }
        }

        return base.ConvertFrom(context, culture, value!);
    }

    private static IEnumerable<(FieldInfo field, EnumMemberAttribute attribute)> GetFields()
    {
        return typeof(T).GetFields().Select(x => (x, Attribute.GetCustomAttribute(x, typeof(EnumMemberAttribute)) as EnumMemberAttribute));
    }
}