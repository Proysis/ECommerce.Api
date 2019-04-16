using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{

    public class Basket : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }

        public Customer Customer { get; set; }
    }
}