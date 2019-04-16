using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace ECommerceCompany.Core.CoreExtensions
{
    public static class CoreExtensions
    {
        public static TResult GetPropertyValue<T, TResult>(this T item, string propertyName) where T : class
        {
            return (TResult)item.GetType().GetProperty(propertyName).GetValue(item);
        }
        public static Guid ToGuid(this object item)
        {
            return Guid.Parse(item.ToString());
        }
    }
}
