using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IProductBasketService : IBaseService<ProductBasket>, IService
    {
        bool IsExists(Guid basketId, Guid productId);
        ProductBasket GetBySuperKeys(Guid basketId, Guid productId);
    }
}
