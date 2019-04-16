using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{
    public class Admin : IEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
