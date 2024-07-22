using System.ComponentModel;

namespace Jobify.Common.Extensions;

public static class EnumExtensions
{
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