using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.DataAccess.EntityFramework;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork
{
    public class EfCustomerDal : BaseDal<Customer>, ICustomerDal
    {
    }
}
