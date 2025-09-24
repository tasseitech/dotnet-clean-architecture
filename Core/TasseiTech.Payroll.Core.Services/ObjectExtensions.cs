using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TasseiTech.Sample.Core.Services.DTOs.Responses;

namespace TasseiTech.Sample.Core.Services;
public static class ObjectExtensions
{
    public static IList<ListItem> EnumToList<TEnum>() where TEnum : struct
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(item => new ListItem
        {
            Text = GetEnumDescription(item as Enum),
            Id = Convert.ToInt32(item)
        }).ToList();
    }

    public static string GetEnumDescription(Enum value)
    {
        if (value == null)
            return null;

        var field = value.GetType().GetField(value.ToString());
        if (field == null)
            return value.ToString();

        var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
    public static string ToJsonArray<TEnum>(this IEnumerable<TEnum> enumList) where TEnum : Enum
    {
        var errorObjects = enumList.Select(enumValue => new
        {
            Code = Convert.ToInt32(enumValue),
            Name = enumValue.ToString()
        });
        return System.Text.Json.JsonSerializer.Serialize(errorObjects);
    }
    public static string ToJsonString<TEnum>(this TEnum errorCode) where TEnum : Enum
    {
        return System.Text.Json.JsonSerializer.Serialize(new
        {
            Code = Convert.ToInt32(errorCode),
            Name = errorCode.ToString()
        });
    }
}
