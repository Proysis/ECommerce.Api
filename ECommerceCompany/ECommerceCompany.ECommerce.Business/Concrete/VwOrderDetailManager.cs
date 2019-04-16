using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class VwOrderDetailManager:BaseManager<IVwOrderDetailDal, VwOrderDetail>, IVwOrderDetailService
    {
        private IVwOrderDetailDal _dal;
        public VwOrderDetailManager(IVwOrderDetailDal dal) : base(dal)
        {
            _dal = dal;
        }

        public List<VwOrderDetail> GetByOrderId(Guid orderId)
        {
            return _dal.GetList(t => t.OrderId == orderId);
        }
    }
}
