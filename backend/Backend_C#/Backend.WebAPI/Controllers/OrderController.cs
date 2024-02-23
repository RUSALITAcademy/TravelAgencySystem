using AutoMapper;
using Backend.Application.Models.Orders.Commands.CreateOrder;
using Backend.Application.Models.Orders.Commands.DeleteOrder;
using Backend.Application.Models.Orders.Commands.UpdateOrder;
using Backend.Application.Models.Orders.Queries.GetOrderDetails;
using Backend.Application.Models.Orders.Queries.GetOrderList;
using Backend.WebAPI.Models.CreateDto;
using Backend.WebAPI.Models.UpdateDto;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebAPI.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper) => _mapper = mapper;



        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsVm>> GetOrder(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                OrderId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderDto createTourDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createTourDto);
            var TourId = await Mediator.Send(command);
            return Ok(TourId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto updateTourDto, Guid id)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateTourDto);
            command.OrderId = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand
            {
                OrderId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderListVm>> GetAllOrdersFromUser(string id)
        {
            var query = new GetOrderListQuery
            {
                UserId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
