using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.Core.Services;

namespace ECommerceCompany.ECommerce.Business.Abstract.Factories
{
    public interface IServiceFactory
    {
        TService CreateService<TService>() where TService: IService;
        object CreateService(Type type);
        void Release<TService>(TService item) where TService : IService;


    }
}
