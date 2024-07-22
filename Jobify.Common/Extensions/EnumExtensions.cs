using System.ComponentModel;

namespace Jobify.Common.Extensions;

public static class EnumExtensions
{
    public static string? GetEnumDescription(this Enum enumValue)
    {
        return enumValue?.GetType()
            ?.GetField(enumValue.ToString())
            ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
            ?.SingleOrDefault() is not DescriptionAttribute attribute
            ? enumValue?.ToString()
            : attribute.Description;
    }

    public static T? GetValueFromDescription<T>(this string? description) where T : Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                if (attribute.Description == description)
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == description)
                    return (T)field.GetValue(null);
            }
        }

        return default;
    }
}