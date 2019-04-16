using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class ProductManager:BaseManager<IProductDal,Product>, IProductService
    {
        public ProductManager(IProductDal dal) : base(dal)
        {
        }

        public List<Product> GetListByProductIds(Guid[] productIds)
        {
            throw new NotImplementedException();
        }
    }
}
