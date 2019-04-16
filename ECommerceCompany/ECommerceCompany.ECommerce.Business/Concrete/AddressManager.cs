using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class AddressManager:BaseManager<IAddressDal,Address>, IAddressService
    {
        private IAddressDal _dal;
        public AddressManager(IAddressDal dal) : base(dal)
        {
            _dal = dal;
        }

        public Address GetCustomShippingAddressByCustomerId(Guid customerId)
        {
           return _dal.Get(t => t.CustomerId == customerId && t.IsCustomShippingAddress);
        }

        public Address GetCustomBillingAddressByCustomerId(Guid customerId)
        {
            return _dal.Get(t => t.CustomerId == customerId && t.IsCustomBillingAddress);
        }
    }
}
