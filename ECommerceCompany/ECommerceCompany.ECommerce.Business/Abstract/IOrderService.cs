using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete.Tables;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IOrderService:IBaseService<Order>, IService
    {
        List<Order> GetByCustomerId(Guid customerId);
    }
}
