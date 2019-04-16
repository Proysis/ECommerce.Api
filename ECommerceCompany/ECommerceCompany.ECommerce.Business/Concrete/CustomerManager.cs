using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class CustomerManager:BaseManager<ICustomerDal,Customer> ,ICustomerService
    {
        private readonly ICustomerDal _dal;
        public CustomerManager(ICustomerDal dal) : base(dal)
        {
            _dal = dal;
        }

        public Customer GetByEmailAndPassword(string email, string password)
        {
            return _dal.Get(t => t.Email == email && t.Password == password);
        }

        public bool HasCustomerByEmail(string email)
        {
            return _dal.Any(t => t.Email == email);
        }
    }
}
