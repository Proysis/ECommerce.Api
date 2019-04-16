using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.ECommerce.Business.Abstract
{
    public interface IBaseService<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity item);
        void AddRange(List<TEntity> itemList);
        void Update(TEntity item);
        void Delete(TEntity item);

        void DeleteRange(List<TEntity> itemList);

        bool IsAnyExists();
        bool IsExists(Guid id);
    }
}
