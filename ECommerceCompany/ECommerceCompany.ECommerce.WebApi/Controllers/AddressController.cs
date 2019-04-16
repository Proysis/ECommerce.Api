using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.Business.Abstract.Factories;
using ECommerceCompany.ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCompany.ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IServiceFactory _serviceFactory;

        public AddressController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet("billing/{customerId}")]
        public IActionResult GetCustomBillingAddress(Guid customerId)
        {
            return Ok(_serviceFactory.CreateService<IAddressService>().GetCustomBillingAddressByCustomerId(customerId));
        }
        [HttpGet("shipping/{customerId}")]
        public IActionResult GetCustomShippingAddress(Guid customerId)
        {
            return Ok(_serviceFactory.CreateService<IAddressService>().GetCustomShippingAddressByCustomerId(customerId));
        }

        [HttpPost("addAddress")]
        public  IActionResult AddAddress(Address address)
        {
            var addressService = _serviceFactory.CreateService<IAddressService>();
            Address dbAddress;
            if (address.IsCustomBillingAddress)
            {
                dbAddress = addressService.GetCustomBillingAddressByCustomerId(address.CustomerId);
                if (dbAddress != null)
                {
                    dbAddress.IsCustomBillingAddress = false;
                    addressService.Update(dbAddress);
                }
            }

            if (address.IsCustomShippingAddress)
            {
                dbAddress = addressService.GetCustomShippingAddressByCustomerId(address.CustomerId);
                if (dbAddress != null)
                {
                    dbAddress.IsCustomShippingAddress = false;
                    addressService.Update(dbAddress);
                }
            }

            if (address.Id != Guid.Empty)
            {
                addressService.Update(address);
            }
            else
            {
                addressService.Add(address);
            }

            return Ok();
        }
    }
}