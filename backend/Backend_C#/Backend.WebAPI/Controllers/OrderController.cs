using AutoMapper;
using Backend.Application.Models.Orders.Commands.CreateOrder;
using Backend.Application.Models.Orders.Commands.DeleteOrder;
using Backend.Application.Models.Orders.Commands.UpdateOrder;
using Backend.Application.Models.Orders.Queries.GetOrderDetails;
using Backend.Application.Models.Orders.Queries.GetOrderList;
using Backend.WebAPI.Models.CreateDto;
using Backend.WebAPI.Models.UpdateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.WebAPI.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TourController> _logger;

        public OrderController(IMapper mapper, ILogger<TourController> logger) 
        {
            _mapper = mapper;
            _logger = logger;
        } 



        [HttpGet("{id}")]
        [Authorize(Roles = "TourAgency, User")]
        public async Task<ActionResult<OrderDetailsVm>> GetOrder(Guid id)
        {
            try
            {
                var query = new GetOrderDetailsQuery
                {
                    OrderId = id
                };
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
                var UserId = HttpContext.User.FindFirstValue("UserId");
                command.RegistrationStartDate = DateTime.UtcNow;
                command.UserId = UserId;
                command.Status = (Domain.Models.OrderStatus)1;
                var TourId = await Mediator.Send(command);
                return Ok(TourId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto updateTourDto, Guid id)
        {
            try
            {
                var command = _mapper.Map<UpdateOrderCommand>(updateTourDto);
                command.OrderId = id;
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            try
            {
                var command = new DeleteOrderCommand
                {
                    OrderId = id
                };
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<OrderListVm>> GetAllOrdersFromUser()
        {
            try
            {
                var UserId =  HttpContext.User.FindFirstValue("UserId");
                var query = new GetOrderListQuery
                {
                    UserId = UserId
                };
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "TourAgent")]
        public async Task<ActionResult<OrderListVm>> GetAllOrdersByTour(Guid id)
        {
            try
            {
                var query = new GetOrderListQuery
                {
                    TourId = id
                };
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }
    }
}
