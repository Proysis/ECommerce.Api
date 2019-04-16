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
    public class AuthController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public AuthController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            Customer customer = _serviceFactory.CreateService<ICustomerService>()
                .GetByEmailAndPassword(loginModel.Email, loginModel.Password);

            if (customer != null)
            {
                CustomerModel customerModel = new CustomerModel
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Email = customer.Email,
                    Phone = customer.Phone
                };

                return Ok(customerModel);
            }


            return NoContent();
        }

        [HttpPost("customerRegister")]
        public IActionResult CustomerRegister([FromBody] Customer customer)
        {
            var service = _serviceFactory.CreateService<ICustomerService>();

            if (service.HasCustomerByEmail(customer.Email))
            {
                return Ok(-1);
            }
            else
            {
                service.Add(customer);
                return Ok(1);
            }
        }
    }
}