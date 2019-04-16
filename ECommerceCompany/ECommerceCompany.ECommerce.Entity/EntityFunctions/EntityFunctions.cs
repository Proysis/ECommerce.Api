using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace ECommerceCompany.Core.CoreFunctions
{
    public class EntityFunctions
    {
        public static void CreateInstanceOfClassFromJsonObject(string className, JObject value, out object ob)
        {
            Type t = Type.GetType("ECommerceCompany.ECommerce.Entity.Concrete." + className, true);

            ob = Activator.CreateInstance(t);


            ob = value.ToObject(t, new JsonSerializer
            {
                DateFormatString = "MM/dd/yyyy",
                Culture = CultureInfo.InvariantCulture,

            });
        }

        public static Type GetYTypeOfClass(string className)
        {
            Type t = Type.GetType("ECommerceCompany.ECommerce.Entity.Concrete." + className, true);
            return t;
        }
    }
}
