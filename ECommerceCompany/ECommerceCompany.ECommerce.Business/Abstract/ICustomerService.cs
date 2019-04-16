using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface ICustomerService:IBaseService<Customer>, IService
    {
        Customer GetByEmailAndPassword(string email, string password);
        bool HasCustomerByEmail(string email);
    }
}
