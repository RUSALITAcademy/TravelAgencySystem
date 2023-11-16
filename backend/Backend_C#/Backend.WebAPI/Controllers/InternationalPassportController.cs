using AutoMapper;
using Backend.Application.Models.InternationalPassport.Commands.CreateInternationalPassport;
using Backend.Application.Models.InternationalPassport.Commands.UpdateInternationalPassport;
using Backend.Application.Models.InternationalPassport.Queries.GetInternationalPassportDetails;
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
    public class InternationalPassportController : BaseController
    {
        private readonly IMapper _mapper;

        public InternationalPassportController(IMapper mapper) => _mapper = mapper;



        [HttpGet("{id}")]
        public async Task<ActionResult<TourDetailsVm>> GetInternationalPassport(Guid id)
        {
            var query = new GetInternationalPassportDetailsQuery
            {
                InternationalPassportId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateInternationalPassport([FromBody] CreateInternationalPassportDto InternationalPassportDto)
        {
            var command = _mapper.Map<CreateInternationalPassportCommand>(InternationalPassportDto);
            var InternationalPassportId = await Mediator.Send(command);
            return Ok(InternationalPassportId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInternationalPassport([FromBody] UpdateInternationalPassportDto updateInternationalPassportDto, Guid id)
        {
            var command = _mapper.Map<UpdateInternationalPassportCommand>(updateInternationalPassportDto);
            command.InternationalPassportId = id;
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
