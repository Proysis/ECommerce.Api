using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Entities;
using ECommerceCompany.Core.Services;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IGenericService:IService
    {
        void Update<TEntity>(TEntity item) where TEntity : class, new();
        void Delete<TEntity>(TEntity item) where TEntity : class, new();
        
    }
}
