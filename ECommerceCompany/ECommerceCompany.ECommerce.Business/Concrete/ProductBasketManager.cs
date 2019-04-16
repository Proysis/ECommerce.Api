using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class ProductBasketManager:BaseManager<IProductBasketDal, ProductBasket>, IProductBasketService
    {
        private IProductBasketDal _dal;

        public ProductBasketManager(IProductBasketDal dal) : base(dal)
        {
            _dal = dal;
        }

        public bool IsExists(Guid basketId, Guid productId)
        {
            return _dal.Any(t => t.BasketId == basketId && t.ProductId == productId);
        }

        public ProductBasket GetBySuperKeys(Guid basketId, Guid productId)
        {
            return _dal.Get(t => t.BasketId == basketId && t.ProductId == productId);
        }
    }
}
