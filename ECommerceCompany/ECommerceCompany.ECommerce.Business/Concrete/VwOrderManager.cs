﻿using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.Entity.Concrete;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class VwOrderManager:BaseManager<IVwOrderDal,VwOrder>, IVwOrderService
    {
        public VwOrderManager(IVwOrderDal dal) : base(dal)
        {
        }
    }
}
