using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.DataAccess;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.DataAccess.Abstract
{
    public interface IBaseDal<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {

    }
}
