using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete.Tables;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class OrderManager:BaseManager<IOrderDal, Order>, IOrderService
    {
        private IOrderDal _dal;
        public OrderManager(IOrderDal dal) : base(dal)
        {
            _dal = dal;
        }

        public List<Order> GetByCustomerId(Guid customerId)
        {
            return _dal.GetList(t => t.CustomerId == customerId);
        }
    }
}
