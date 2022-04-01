using System.Runtime.Serialization;

namespace App;

public static class Extensions
{
    public static void WriteLine(this ConsoleColor color, object value)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(value);
        Console.ResetColor();
    }

    public static string GetName<T>(this T _) => typeof(T).GetName();

    public static string GetName(this Type type)
    {
        var name = type.Name;
        var index = name.IndexOf('`');
        return index == -1 ? name : name[..index];
    }

    public static string ToEnumMember(this Enum enumValue)
    {
        var type = enumValue.GetType();
        var info = type.GetField(enumValue.ToString());
        var attribute = (EnumMemberAttribute[])info?.GetCustomAttributes(typeof(EnumMemberAttribute), false);
        return attribute?.FirstOrDefault()?.Value;
    }
}