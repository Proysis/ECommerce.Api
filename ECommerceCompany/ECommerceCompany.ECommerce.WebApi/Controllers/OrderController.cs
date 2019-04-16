using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceCompany.Core.CoreFunctions;
using ECommerceCompany.ECommerce.Business.Abstract;
using ECommerceCompany.ECommerce.Business.Abstract.Factories;
using ECommerceCompany.ECommerce.Entity.Concrete;
using ECommerceCompany.ECommerce.Entity.Concrete.Tables;
using ECommerceCompany.ECommerce.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCompany.ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public OrderController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost("addNewOrder")]
        public IActionResult AddNewOrder(OrderModel orderModel)
        {
            var basketService = _serviceFactory.CreateService<IBasketService>();
            var productBasketService = _serviceFactory.CreateService<IVwProductBasketService>();
            var orderDetailService = _serviceFactory.CreateService<IOrderDetailService>();
            Basket basket = basketService.GetById(orderModel.BasketId);

            if (basket != null)
            {
                List<VwProductBasket> productBasketList = productBasketService.GetListByBasketId(basket.CustomerId, basket.Id);

                if (productBasketList.Any())
                {
                    Order order = new Order
                    {
                        CustomerId = basket.CustomerId,
                        Date = DateTime.Now,
                        OrderCode = RandomParameters.GenerateRandom(10),
                        TotalPrice = basket.Total,
                        BillingAddress = orderModel.BillingAddress,
                        ShippingAddress = orderModel.ShippingAddress
                    };

                    _serviceFactory.CreateService<IOrderService>().Add(order);


                    List<OrderDetail> orderDetailList = new List<OrderDetail>();
                    OrderDetail orderDetail;

                    foreach (var item in productBasketList)
                    {
                        orderDetail = new OrderDetail
                        {
                            OrderId = order.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.Price
                        };

                        orderDetailList.Add(orderDetail);
                    }

                    orderDetailService.AddRange(orderDetailList);
                }

                basket.Status = true;

                basketService.Update(basket);
            }

            return Ok();
        }

        [HttpGet("customerOrders/{customerId}")]
        public IActionResult GetOrdersByCustomer(Guid customerId)
        {
            return Ok(_serviceFactory.CreateService<IOrderService>().GetByCustomerId(customerId));
        }

        [HttpGet("orderDetails/{orderId}")]
        public IActionResult GetOrdersByOrder(Guid orderId)
        {
            return Ok(_serviceFactory.CreateService<IVwOrderDetailService>().GetByOrderId(orderId));
        }
    }
}