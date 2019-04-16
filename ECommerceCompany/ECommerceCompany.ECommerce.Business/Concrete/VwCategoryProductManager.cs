using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete.Views;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class VwCategoryProductManager:BaseManager<IVwCategoryProductDal, VwCategoryProducts>
    {
        public VwCategoryProductManager(IVwCategoryProductDal dal) : base(dal)
        {
        }
    }
}
