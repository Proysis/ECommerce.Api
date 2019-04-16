using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.Business.Abstract.Factories;
using ECommerceCompany.ECommerce.Entity.Concrete;
using ECommerceCompany.ECommerce.Entity.Concrete.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCompany.ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public CategoryController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_serviceFactory.CreateService<ICategoryService>().GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(Guid id)
        {
            return Ok(_serviceFactory.CreateService<ICategoryService>().GetById(id));
        }

       
    }
}