using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.CoreExtensions;
using ECommerceCompany.Core.Entities;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;

namespace ECommerceCompany.ECommerce.Business.Concrete
{
    public class BaseManager<TDal, TEntity> : IBaseService<TEntity> where TDal : class, IBaseDal<TEntity> where TEntity : class, IEntity, new()
    {
        private TDal _dal;

        public BaseManager(TDal dal)
        {
            _dal = dal;
        }

        public List<TEntity> GetAll()
        {
            return _dal.GetList();
        }

        public TEntity GetById(Guid id)
        {
            return _dal.Get(t => t.GetPropertyValue<TEntity, Guid>("Id") == id);
        }

        public void Add(TEntity item)
        {
            _dal.Add(item);
        }

        public void AddRange(List<TEntity> itemList)
        {
            _dal.AddRange(itemList);
        }

        public void Update(TEntity item)
        {
            _dal.Update(item);
        }

        public void Delete(TEntity item)
        {
            _dal.Delete(item);
        }

        public void DeleteRange(List<TEntity> itemList)
        {
            _dal.DeleteRange(itemList);
        }

        public bool IsAnyExists()
        {
            return _dal.Any();
        }

        public bool IsExists(Guid id)
        {
            return _dal.Any(t=>t.GetPropertyValue<TEntity, Guid>("Id") == id);
        }
        
    }
}
