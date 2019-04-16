using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete.Tables;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class OrderDetailManager:BaseManager<IOrderDetailDal, OrderDetail>, IOrderDetailService
    {
        private readonly IOrderDetailDal _dal;
        public OrderDetailManager(IOrderDetailDal dal) : base(dal)
        {
            _dal = dal;
        }

        public List<OrderDetail> GetByOrderId(Guid orderId)
        {
            return _dal.GetList(t => t.OrderId == orderId);
        }
    }
}
