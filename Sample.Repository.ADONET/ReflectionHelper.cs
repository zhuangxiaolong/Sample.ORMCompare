using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sample.Repository.ADONET
{
    public static class ReflectionHelper
    {
        public static void SetValue<T>(string propertyName, object value, T t)
        {
            var propertyInfo = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var pInfo in propertyInfo)
            {
                if (string.CompareOrdinal(propertyName, pInfo.Name) != 0) continue;
                //给属性赋值
                pInfo.SetValue((object)t, value, null);
                break;
            }
        }
    }
}
