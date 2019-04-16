using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCompany.ECommerce.WebApi.Models
{
    public class OrderModel
    {
        public Guid BasketId { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
    }
}
