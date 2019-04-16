using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class BasketManager:BaseManager<IBasketDal, Basket>, IBasketService
    {
        private IBasketDal _dal;
        public BasketManager(IBasketDal dal) : base(dal)
        {
            _dal = dal;
        }

        public Basket GetHasNoOrder(Guid customerId)
        {
            return _dal.Get(t => t.CustomerId == customerId && t.Status == false);
        }
        
    }
}
