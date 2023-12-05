using AutoMapper;
using Backend.Application.Models.Tours.Commands.CreateTour;
using Backend.Application.Models.Tours.Commands.DeleteTour;
using Backend.Application.Models.Tours.Commands.UpdateTour;
using Backend.Application.Models.Tours.Queries.GetTourDetails;
using Backend.Application.Models.Tours.Queries.GetTourList;
using Backend.WebAPI.Models.CreateDto;
using Backend.WebAPI.Models.UpdateDto;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebAPI.Controllers
{
    public class TourController : BaseController
    {
        private readonly IMapper _mapper;

        public TourController(IMapper mapper) => _mapper = mapper;



        [HttpGet("{id}")]
        public async Task<ActionResult<TourDetailsVm>> GetTour(Guid id)
        {
            var query = new GetTourDetailsQuery
            {
                TourId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTour([FromBody] CreateTourDto createTourDto)
        {
            var command = _mapper.Map<CreateTourCommand>(createTourDto);
            var TourId = await Mediator.Send(command);
            return Ok(TourId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTour([FromBody] UpdateTourDto updateTourDto, Guid id)
        {
            var command = _mapper.Map<UpdateTourCommand>(updateTourDto);
            command.TourId = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(Guid id)
        {
            var command = new DeleteTourCommand
            {
                TourId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<TourListVm>> GetAllTours()
        {
            var query = new GetTourListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
