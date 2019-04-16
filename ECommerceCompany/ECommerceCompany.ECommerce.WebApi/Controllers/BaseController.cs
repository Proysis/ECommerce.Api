using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ECommerceCompany.Core.CoreExtensions;
using ECommerceCompany.Core.CoreFunctions;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.Business.Abstract.Factories;
using ECommerceCompany.ECommerce.Business.BusinessFunctions;
using ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork;
using ECommerceCompany.ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ECommerceCompany.ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public BaseController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] JObject value)
        {
            string className = value["className"].ToString();
            value.Property("className").Remove();
            string serviceName = value["serviceName"].ToString();
            value.Property("serviceName").Remove();

            Type type = BusinessFunctions.GetYTypeOfClass(serviceName);

            EntityFunctions.CreateInstanceOfClassFromJsonObject(className, value, out object ob);
            object[] param = new[] { ob };

            string id = ob.GetPropertyValue<object, object>("Id").ToString();

            Type serviceType = _serviceFactory.CreateService(type).GetType();


            MethodInfo methodInfo = id != Guid.Empty.ToString() && !string.IsNullOrEmpty(id)
                ? serviceType.GetMethod("Update")
                : serviceType.GetMethod("Add");

            methodInfo.Invoke(_serviceFactory.CreateService(type), param);

            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] JObject value)
        {
            string className = value["className"].ToString();
            value.Property("className").Remove();
            string serviceName = value["serviceName"].ToString();
            value.Property("serviceName").Remove();

            Type type = BusinessFunctions.GetYTypeOfClass(serviceName);

            EntityFunctions.CreateInstanceOfClassFromJsonObject(className, value, out object ob);
            object[] param = new[] { ob };

            _serviceFactory.CreateService(type).GetType().GetMethod("Delete")
                .Invoke(_serviceFactory.CreateService(type), param);

            return Ok();
        }

        [HttpGet("{serviceName}")]
        public IActionResult GetAll(string serviceName)
        {
            Type type = BusinessFunctions.GetYTypeOfClass(serviceName);
            return Ok(_serviceFactory.CreateService(type).GetType().GetMethod("GetAll").Invoke(_serviceFactory.CreateService(type), null));
        }
        [HttpGet("{serviceName}/{id}")]
        public IActionResult GetById(string serviceName, Guid id)
        {
            Type type = BusinessFunctions.GetYTypeOfClass(serviceName);
            object[] param = { id };
            return Ok(_serviceFactory.CreateService(type).GetType().GetMethod("GetById").Invoke(_serviceFactory.CreateService(type), param));
        }
    }
}