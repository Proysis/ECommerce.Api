using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ECommerceCompany.Core.CoreExtensions;
using ECommerceCompany.Core.DataAccess.EntityFramework;
using ECommerceCompany.ECommerce.DataAccess.Abstract;

namespace ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork
{
    public class EfGenericDal<TEntity> : EfGenericReporsitoryBase<TEntity, ECommerceDBContext>, IGenericDal<TEntity> where TEntity : class, new()
    {
    }
}
