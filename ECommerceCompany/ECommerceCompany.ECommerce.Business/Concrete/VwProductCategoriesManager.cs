using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete.Views;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class VwProductCategoriesManager:BaseManager<IVwProductCategoriesDal, VwProductCategories>, IVwProductCategoriesService
    {
        private IVwProductCategoriesDal _dal;
        public VwProductCategoriesManager(IVwProductCategoriesDal dal) : base(dal)
        {
            _dal = dal;
        }

        public List<VwProductCategories> GetByCategories(Guid[] categoryIds)
        {
            return _dal.GetList(t => t.CategoryIds.ToList().Exists(categoryIds.Contains));
        }
        
    }
}
