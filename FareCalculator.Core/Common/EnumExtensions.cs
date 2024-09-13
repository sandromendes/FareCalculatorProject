using System;
using System.ComponentModel;
using System.Reflection;

namespace FareCalculator.Core.Common
{
    public static  class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (attribute != null && attribute.Description == description)
                    return (T)field.GetValue(null);

                if (field.Name == description)
                    return (T)field.GetValue(null);
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
    }
}
