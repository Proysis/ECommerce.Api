using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class VwProductBasketManager:BaseManager<IVwProductBasketDal, VwProductBasket>, IVwProductBasketService
    {
        private IVwProductBasketDal _dal;
        public VwProductBasketManager(IVwProductBasketDal dal) : base(dal)
        {
            _dal = dal;
        }

        public List<VwProductBasket> GetListByCustomerId(Guid customerId)
        {
            return _dal.GetList(t => t.CustomerId == customerId && !t.Status);
        }

        public List<VwProductBasket> GetListByBasketId(Guid customerId, Guid basketId)
        {
            return _dal.GetList(t => t.CustomerId ==customerId && t.BasketId == basketId);
        }

        public decimal GetTotalPriceByBasketId(Guid basketId)
        {
            decimal sum = _dal.GetList(t => t.BasketId == basketId && !t.Status).Sum(t=>t.TotalPrice);
            return sum;
        }
    }
}
