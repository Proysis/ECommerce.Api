using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{

    public class Address : IEntity
    {
        
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string PhoneNumbers { get; set; }

        public bool IsCustomBillingAddress { get; set; }
        public bool IsCustomShippingAddress { get; set; }

        public Customer Customer { get; set; }
        
    }
}