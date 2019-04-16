using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.DataAccess.EntityFramework;
using ECommerceCompany.Core.Entities;
using ECommerceCompany.ECommerce.DataAccess.Abstract;

namespace ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork
{
    public class BaseDal<TEntity> : EfEntityRepositoryBase<TEntity, ECommerceDBContext>, IBaseDal<TEntity> where TEntity : class, IEntity, new()
    {
    }
}
