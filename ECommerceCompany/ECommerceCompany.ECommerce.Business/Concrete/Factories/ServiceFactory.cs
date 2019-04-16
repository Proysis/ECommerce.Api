using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ECommerceCompany.Core.Services;
using ECommerceCompany.ECommerce.Business.Abstract.Factories;
using Ninject;

namespace ECommerceCompany.ECommerce.Business.Concrete.Factories
{
    public class ServiceFactory:IServiceFactory
    {
        private readonly IKernel kernel;
        public ServiceFactory()
        {
            kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
        }
        public TService CreateService<TService>() where TService : IService
        {
            return kernel.Get<TService>();
        }
        public object CreateService(Type type)
        {
            return kernel.Get(type);
        }

        public void Release<TService>(TService item) where TService : IService
        {
            kernel.Release(item);
        }
    }
}
