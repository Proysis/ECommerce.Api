using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.DataAccess;

namespace ECommerceCompany.ECommerce.DataAccess.Abstract
{
    public interface IGenericDal<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
    }
}
