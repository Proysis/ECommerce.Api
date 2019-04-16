using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete.Views;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IVwProductCategoriesService:IBaseService<VwProductCategories>, IService
    {
        List<VwProductCategories> GetByCategories(Guid[] categoryIds);
    }
}
