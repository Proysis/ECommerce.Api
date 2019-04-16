﻿using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{
    public class VwOrder : IEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string OrderCode { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }

        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
