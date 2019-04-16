using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ECommerceCompany.Core.Entities;

namespace ECommerceCompany.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void AddRange(List<T> entityList);

        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(List<T> entityList);

        bool Any(Expression<Func<T, bool>> filter = null);
    }
}
