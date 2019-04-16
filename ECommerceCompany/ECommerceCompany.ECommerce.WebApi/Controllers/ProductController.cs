using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.Business.Abstract.Factories;
using ECommerceCompany.ECommerce.Entity.Concrete;
using ECommerceCompany.ECommerce.Entity.Concrete.Views;
using ECommerceCompany.ECommerce.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCompany.ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IServiceFactory _serviceFactory;

        public ProductController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

     

        [HttpPost("InsertOrUpdate")]
        public IActionResult InsertOrUpdate(ProductUpdateModel productUpdateModel)
        {

            var service = _serviceFactory.CreateService<IProductService>();
            var productCategoryService = _serviceFactory.CreateService<IProductCategoryService>();
            if (productUpdateModel.Product.Id != Guid.Empty)
            {
                service.Update(productUpdateModel.Product);
            }
            else
            {
                service.Add(productUpdateModel.Product);
            }

            List<ProductCategory> productCategories = productCategoryService.GetListByProductId(productUpdateModel.Product.Id);
            Guid[] addedCategoryIds;
            if (productCategories.Any())
            {
                addedCategoryIds =
                   productUpdateModel.CategoryIds.Where(t => !productCategories.Exists(p => p.CategoryId == t)).ToArray();

                List<ProductCategory> removedProductCategories = productCategories.Where(t => !productUpdateModel.CategoryIds.Contains(t.CategoryId)).ToList();

                if (removedProductCategories.Any())
                {
                    productCategoryService.DeleteRange(removedProductCategories);
                }
            }
            else
            {
                addedCategoryIds = productUpdateModel.CategoryIds;
            }

            if (addedCategoryIds.Any())
            {
                List<ProductCategory> addedProductCategories = new List<ProductCategory>();
                foreach (Guid id in addedCategoryIds)
                {
                    addedProductCategories.Add(new ProductCategory { ProductId = productUpdateModel.Product.Id, CategoryId = id });
                }

                productCategoryService.AddRange(addedProductCategories);
            }

            return Ok();
        }

        [HttpPost("products")]
        public IActionResult GetProducts(Guid[] categoryIds)
        {
            if (categoryIds.Any())
            {
                List<VwProductCategories> productCategories = _serviceFactory
                    .CreateService<IVwProductCategoriesService>().GetByCategories(categoryIds);
                return Ok(productCategories);
            }

            return Ok(_serviceFactory.CreateService<IVwProductCategoriesService>().GetAll());
        }
    }
}