using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestHB.Domain.Commands;
using BestHB.Domain.Queries;
using BestHB.Domain.Repositories;
using BestHB.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using BestHB.Domain.Services;

namespace BestHB.Controllers
{
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        public readonly OrderService _orderService;
        private readonly IRepository _orderRepository;

        public OrdersController(OrderService orderService, IRepository orderRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody]CreateOrderCommand command)
        {
            try
            {
                var orderId = _orderService.Create(command);
                return Ok(orderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //Seria bom colocar uma mensagem personalizada no badRequest
            }
        }

        [HttpPost]
        [Route("delete")] //O caminho devia ter o Id da order que esta sendo deletada
        public IActionResult Delete([FromBody]DeleteOrderCommand command)
        {
            try
            {
                var status = _orderService.Delete(command); //Nao acontece nada, acho que retorna Ok mesmo nao deletando
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //Seria bom colocar uma mensagem personalizada no badRequest
			}
        }

        [HttpPost]
        [Route("get")] //É um post nao um Get
        public async Task<IActionResult> Get([FromBody]QueryOrders queryOrders)
        {
            try
            {
                var orders = await _orderRepository.Get(queryOrders);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("csv")]
        public async Task<IActionResult> GetAsCSV([FromBody] QueryOrders queryOrders)
        {
            try
            {
                return Ok(await _orderService.AsCSV(queryOrders));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}