using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ECommerceCompany.Core.CoreExtensions;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Entity.Concrete.Views
{

    public class VwProductCategories : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ProductCategories { get; set; }

        public Guid[] CategoryIds
        {
            get
            {
                string[] sItems = ProductCategories.Split(',');
                Guid[] items= new Guid[sItems.Length-1];
                for (int i = 0; i<sItems.Length; i++)
                {
                    if (!string.IsNullOrEmpty(sItems[i]))
                    {
                        items[i] = sItems[i].ToGuid();
                    }
                }

                return items;
            }
        }
    }
}