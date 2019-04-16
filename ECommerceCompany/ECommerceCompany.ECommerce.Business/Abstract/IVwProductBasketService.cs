using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IVwProductBasketService:IBaseService<VwProductBasket>, IService
    {
        List<VwProductBasket> GetListByCustomerId(Guid customerId);
        List<VwProductBasket> GetListByBasketId(Guid customerId, Guid basketId);
        decimal GetTotalPriceByBasketId(Guid basketId);

        
    }
}
