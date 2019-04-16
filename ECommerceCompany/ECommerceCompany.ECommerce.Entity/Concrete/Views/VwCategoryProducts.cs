using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete.Views
{

    public class VwCategoryProducts : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryProducts { get; set; }

    }
}