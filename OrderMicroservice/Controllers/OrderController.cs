using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Models;
using OrderMicroservice.Repository;
using Serilog;

namespace OrderMicroservice.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository orderRepository;
        public OrderController(IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
        }
        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                Log.Debug("Orders Getting Started");                
                var orders = await orderRepository.GetOrders();
                Log.Debug("Orders Getted", orders);
                if (orders == null)
                {
                    return NotFound();
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Log.Error("Orders Getting Failed", ex);
                throw new Exception("Orders Getting Failed", innerException: ex);
            }
        }

        [HttpGet]
        [Route("GetOrder")]
        public async Task<IActionResult> GetOrder(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return BadRequest();
            }
            try
            {
                Log.Debug("Order Getting Started");
                Log.Debug("Order Getting Input", id);
                var order = await orderRepository.Get(id);
                Log.Debug("Order Getting Output", order);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                Log.Error("Order Getting Failed", ex);
                throw new Exception("Order Getting Failed", innerException: ex);
            }
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Log.Debug("Order Addition Started");
                    Log.Debug("Order Addition Input", order);
                    var orderId = await orderRepository.Post(order);
                    Log.Debug("Order Addition Output", orderId);
                    if (orderId != Guid.Empty)
                    {
                        return Ok(orderId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Order Addition Failed", ex);
                    throw new Exception("Order Addition Failed", innerException: ex);
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Log.Debug("Order Updation Started");
                    Log.Debug("Order Updation Input", order);
                    await orderRepository.Update(order);
                    Log.Debug("Order Addition Output", order);
                    return Ok();
                }
                catch (Exception ex)
                {
                    Log.Error("Order Updation Failed", ex);
                    throw new Exception("Order Updation Failed", innerException: ex);
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(Guid? id)
        {
            int result = 0;

            if (id == null || id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                Log.Debug("Order Deletion Started");
                Log.Debug("Order Deletion Input", id);
                result = await orderRepository.Delete(id);
                Log.Debug("Order Deletion Output", result);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Order Updation Failed", ex);
                throw new Exception("Order Updation Failed", innerException: ex);
            }
        }
    }
}