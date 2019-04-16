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
    public class BasketController : ControllerBase
    {
        private IServiceFactory _serviceFactory;

        public BasketController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost("addToBasket")]
        public IActionResult AddToBasket(VwProductBasket productBasketModel)
        {
            var basketService = _serviceFactory.CreateService<IBasketService>();
            var productBasketService = _serviceFactory.CreateService<IProductBasketService>();

            Basket basket = basketService.GetHasNoOrder(productBasketModel.CustomerId);

            if (basket != null)
            {
                productBasketModel.BasketId = basket.Id;
            }
            else
            {
                basket = new Basket
                {
                    CustomerId = productBasketModel.CustomerId,
                    Status = false,
                    Date = DateTime.Now,
                    Total = (decimal)0.0
                };

                basketService.Add(basket);
                productBasketModel.BasketId = basket.Id;
            }

            var productBasket = productBasketService.GetBySuperKeys(productBasketModel.BasketId, productBasketModel.ProductId);
            if (productBasket != null)
            {
                productBasket.Quantity = productBasketModel.Quantity;
                productBasketService.Update(productBasket);
            }
            else
            {
                productBasket = new ProductBasket
                {
                    BasketId = productBasketModel.BasketId,
                    ProductId = productBasketModel.ProductId,
                    Quantity = productBasketModel.Quantity
                };
                productBasketService.Add(productBasket);
            }

            basket.Total = _serviceFactory.CreateService<IVwProductBasketService>().GetTotalPriceByBasketId(basket.Id);
            basketService.Update(basket);

            return Ok();
        }

        [HttpPost("addListToBasket")]
        public IActionResult AddListToBasket(List<VwProductBasket> productBasketModelList)
        {
            var basketService = _serviceFactory.CreateService<IBasketService>();
            var productBasketService = _serviceFactory.CreateService<IProductBasketService>();

            Basket basket = basketService.GetHasNoOrder(productBasketModelList.First().CustomerId);
            
            if(basket == null)
            {
                basket = new Basket
                {
                    CustomerId = productBasketModelList.First().CustomerId,
                    Status = false,
                    Date = DateTime.Now,
                    Total = (decimal)0.0
                };

                basketService.Add(basket);
            }

            ProductBasket productBasket;
            foreach (var item in productBasketModelList)
            {
                item.BasketId = basket.Id;
                productBasket = productBasketService.GetBySuperKeys(item.BasketId, item.ProductId);

                if (productBasket != null)
                {
                    productBasket.Quantity = item.Quantity;
                    productBasketService.Update(productBasket);
                }
                else
                {
                    productBasket = new ProductBasket
                    {
                        BasketId = item.BasketId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    productBasketService.Add(productBasket);
                }
            }

            basket.Total = _serviceFactory.CreateService<IVwProductBasketService>().GetTotalPriceByBasketId(basket.Id);
            basketService.Update(basket);
            return Ok();
        }

        [HttpGet("getAllByCustomerId/{customerId}")]
        public IActionResult GetAllByCustomerId(Guid customerId)
        {
            return Ok(_serviceFactory.CreateService<IVwProductBasketService>().GetListByCustomerId(customerId));
        }

        [HttpPost("deleteFromBasket")]
        public IActionResult DeleteFromBasket(ProductBasket productBasket)
        {
            var productBasketService = _serviceFactory.CreateService<IProductBasketService>();
            productBasketService.Delete(productBasket);

            var basketService = _serviceFactory.CreateService<IBasketService>();

            Basket basket = basketService.GetById(productBasket.BasketId);

            basket.Total = _serviceFactory.CreateService<IVwProductBasketService>().GetTotalPriceByBasketId(basket.Id);

            basketService.Update(basket);

            return Ok();
        }
    }
}