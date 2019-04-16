using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{

    public class ProductBasket : IEntity
    {
        [Key]
        public Guid ProductId { get; set; }
        [Key]
        public Guid BasketId { get; set; }

        public int Quantity { get; set; }

    }
}