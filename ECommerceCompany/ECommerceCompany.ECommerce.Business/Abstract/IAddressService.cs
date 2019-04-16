using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IAddressService:IBaseService<Address>, IService
    {
        Address GetCustomShippingAddressByCustomerId(Guid customerId);
        Address GetCustomBillingAddressByCustomerId(Guid customerId);
    }
}
