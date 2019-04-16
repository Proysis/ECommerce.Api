using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class AdminManager:BaseManager<IAdminDal,Admin>, IAdminService
    {
        private readonly IAdminDal _dal;
        public AdminManager(IAdminDal dal) : base(dal)
        {
            _dal = dal;
        }

        public Admin GetByUserNameAndPassword(string userName, string password)
        {
            return _dal.Get(t => t.UserName == userName && t.Password == password);
        }
    }
}
