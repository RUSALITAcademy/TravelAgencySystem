using AutoMapper;
using Backend.Application.Models.InternationalPassport.Commands.CreateInternationalPassport;
using Backend.Application.Models.Passport.Commands.CreatePassport;
using Backend.Application.Models.Passport.Commands.UpdatePassport;
using Backend.Application.Models.Passport.Queries.GetPassportDetails;
using Backend.WebAPI.Models.CreateDto;
using Backend.WebAPI.Models.UpdateDto;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebAPI.Controllers
{
    public class PassportController : BaseController
    {
        private readonly IMapper _mapper;

        public PassportController(IMapper mapper) => _mapper = mapper;



        [HttpGet("{id}")]
        public async Task<ActionResult<PassportDetailsVm>> GetPassport(Guid id)
        {
            var query = new GetPassportDetailsQuery
            {
                PassportId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePassport([FromBody] CreatePassportDto PassportDto)
        {
            var command = _mapper.Map<CreatePassportCommand>(PassportDto);
            var PassportId = await Mediator.Send(command);
            return Ok(PassportId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassport([FromBody] UpdatePassportDto updatePassportDto, Guid id)
        {
            var command = _mapper.Map<UpdatePassportCommand>(updatePassportDto);
            command.PassportId = id;
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
