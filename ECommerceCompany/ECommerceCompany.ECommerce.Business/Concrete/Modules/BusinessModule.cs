using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Abstract;
using ECommerceCompany.ECommerce.DataAccess.Concrete;
using ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork;
using Ninject.Modules;

namespace ECommerceCompany.ECommerce.Business.Concrete.Modules
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<IAddressService>().To<AddressManager>().InSingletonScope();
            Bind<IAddressDal>().To<EfAddressDal>().InSingletonScope();

            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IBasketService>().To<BasketManager>().InSingletonScope();
            Bind<IBasketDal>().To<EfBasketDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IAdminService>().To<AdminManager>().InSingletonScope();
            Bind<IAdminDal>().To<AdminDal>().InSingletonScope();
            
            Bind<IProductBasketService>().To<ProductBasketManager>().InSingletonScope();
            Bind<IProductBasketDal>().To<EfProductBasketDal>().InSingletonScope();

            Bind<IProductCategoryService>().To<ProductCategoryManager>().InSingletonScope();
            Bind<IProductCategoryDal>().To<EfProductCategoryDal>().InSingletonScope();

            Bind<IOrderService>().To<OrderManager>().InSingletonScope();
            Bind<IOrderDal>().To<EfOrderDal>().InSingletonScope();

            Bind<IOrderDetailService>().To<OrderDetailManager>().InSingletonScope();
            Bind<IOrderDetailDal>().To<EfOrderDetailDal>().InSingletonScope();

            Bind<IVwProductCategoriesService>().To<VwProductCategoriesManager>().InSingletonScope();
            Bind<IVwProductCategoriesDal>().To<EfVwProductCategoriesDal>().InSingletonScope();
            
            Bind<IVwProductBasketService>().To<VwProductBasketManager>().InSingletonScope();
            Bind<IVwProductBasketDal>().To<EfVwProductBasketDal>().InSingletonScope();
            
            Bind<IVwOrderService>().To<VwOrderManager>().InSingletonScope();
            Bind<IVwOrderDal>().To<EfVwOrderDal>().InSingletonScope();

            Bind<IVwOrderDetailService>().To<VwOrderDetailManager>().InSingletonScope();
            Bind<IVwOrderDetailDal>().To<EfVwOrderDetailDal>().InSingletonScope();

            Bind<IGenericService>().To<GenericManager>().InSingletonScope();
        }
    }
}
