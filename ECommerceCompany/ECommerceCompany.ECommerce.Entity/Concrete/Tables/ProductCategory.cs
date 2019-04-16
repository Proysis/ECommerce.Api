using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{

    public class ProductCategory : IEntity
    {
        [Key]
        public Guid ProductId { get; set; }
        [Key]
        public Guid CategoryId { get; set; }

    }
}