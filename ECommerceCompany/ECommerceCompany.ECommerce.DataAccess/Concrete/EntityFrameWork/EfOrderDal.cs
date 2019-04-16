using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete.Tables;

namespace ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork
{
    public class EfOrderDal:BaseDal<Order>, IOrderDal
    {
    }
}
