using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{
    public class VwProductBasket : IEntity
    {
        public Guid ProductId { get; set; }
        public Guid BasketId { get; set; }
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }      
    }
}
