using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    class ProductCategoryManager:BaseManager<IProductCategoryDal, ProductCategory>, IProductCategoryService
    {
        private IProductCategoryDal _dal;

        public ProductCategoryManager(IProductCategoryDal dal) : base(dal)
        {
            _dal = dal;
        }

        public List<ProductCategory> GetListByProductId(Guid productId)
        {
            return _dal.GetList(t => t.ProductId == productId);
        }

        public List<ProductCategory> GetListByCategoryIds(Guid[] categoryIds)
        {
            return _dal.GetList(t=> categoryIds.Contains(t.CategoryId));
        }
    }
}
