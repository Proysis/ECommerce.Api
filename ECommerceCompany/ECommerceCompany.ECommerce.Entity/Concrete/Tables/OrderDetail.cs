using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete.Tables
{
    public class OrderDetail:IEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
