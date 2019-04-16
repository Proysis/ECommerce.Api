using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete.Tables;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IOrderDetailService:IBaseService<OrderDetail>,IService
    {
        List<OrderDetail> GetByOrderId(Guid orderId);
    }
}
