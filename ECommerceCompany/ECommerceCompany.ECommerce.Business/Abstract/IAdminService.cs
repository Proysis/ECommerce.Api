﻿using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IAdminService : IBaseService<Admin>, IService
    {
        Admin GetByUserNameAndPassword(string userName, string password);
    }
}
