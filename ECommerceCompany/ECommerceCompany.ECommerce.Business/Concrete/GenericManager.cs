using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Entities;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class GenericManager : IGenericService
    {

        public void Update<TEntity>(TEntity item) where TEntity : class, new()
        {
            IGenericDal<TEntity> genericDal = new EfGenericDal<TEntity>();
            genericDal.Update(item);
        }

        public void Delete<TEntity>(TEntity item) where TEntity : class, new()
        {
            IGenericDal<TEntity> genericDal = new EfGenericDal<TEntity>();
            genericDal.Update(item);
        }
        
    }
}
