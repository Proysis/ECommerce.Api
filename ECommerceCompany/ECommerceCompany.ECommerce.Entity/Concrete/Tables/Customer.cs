using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete
{

    public class Customer : IEntity
    {

        public Customer()
        {
            Basket = new List<Basket>();
            Address = new List<Address>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public List<Basket> Basket { get; set; }
        public List<Address> Address { get; set; }
    }
}