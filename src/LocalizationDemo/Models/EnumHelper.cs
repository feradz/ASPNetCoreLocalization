using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace LocalizationDemo.Models
{
    public static class EnumHelper
    {
        public static string DisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var memberInfo = enumType.GetMember(enumValue.ToString()).First();

            if (memberInfo == null || !memberInfo.CustomAttributes.Any()) return enumValue.ToString();

            var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute == null) return enumValue.ToString();

            if (displayAttribute.ResourceType != null && displayAttribute.Name != null)
            {
                var manager = new ResourceManager(displayAttribute.ResourceType);
                return manager.GetString(displayAttribute.Name);
            }

            return displayAttribute.Name ?? enumValue.ToString();
        }
    }
}
