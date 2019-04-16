using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.Business.Abstract.Factories;
using ECommerceCompany.ECommerce.Entity.Concrete;
using ECommerceCompany.ECommerce.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCompany.ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public AdminController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AdminLoginModel loginModel)
        {
            Admin admin = _serviceFactory.CreateService<IAdminService>()
                .GetByUserNameAndPassword(loginModel.UserName, loginModel.Password);

            if (admin != null)
            {
                OnlineAdminModel adminModel = new OnlineAdminModel
                {
                    Id = admin.Id,
                    UserName = admin.UserName
                };

                return Ok(adminModel);
            }

            return NoContent();
        }
    }
}