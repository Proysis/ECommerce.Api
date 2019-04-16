using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.WebApi.Models
{
    public class ProductUpdateModel
    {
        public Product Product { get; set; }
        public Guid[] CategoryIds { get; set; }
    }
}
