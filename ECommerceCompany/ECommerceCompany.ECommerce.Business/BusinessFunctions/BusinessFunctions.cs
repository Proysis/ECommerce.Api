using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ECommerceCompany.ECommerce.Business.BusinessFunctions
{
    public class BusinessFunctions
    {
        public static Type GetYTypeOfClass(string className)
        {
            Type t = Type.GetType("ECommerceCompany.ECommerce.Business.Abstract." + className, true);
            return t;
        }
    }
}
