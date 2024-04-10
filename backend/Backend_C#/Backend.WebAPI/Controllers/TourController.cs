using AutoMapper;
using Backend.Application.Models.Tours.Commands.CreateTour;
using Backend.Application.Models.Tours.Commands.DeleteTour;
using Backend.Application.Models.Tours.Commands.UpdateTour;
using Backend.Application.Models.Tours.Queries.GetTourDetails;
using Backend.Application.Models.Tours.Queries.GetTourList;
using Backend.Domain.Models;
using Backend.WebAPI.Models.CreateDto;
using Backend.WebAPI.Models.UpdateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebAPI.Controllers
{
    public class TourController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TourController(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        




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
        [Authorize(Roles = "TourAgency")]
        public async Task<ActionResult<Guid>> CreateTour([FromBody] CreateTourDto createTourDto)
        {
            //HttpContext.User.IsInRole();
            var command = _mapper.Map<CreateTourCommand>(createTourDto);
            var TourId = await Mediator.Send(command);
            return Ok(TourId);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "TourAgency")]
        public async Task<IActionResult> UpdateTour([FromBody] UpdateTourDto updateTourDto, Guid id)
        {
            var command = _mapper.Map<UpdateTourCommand>(updateTourDto);
            command.TourId = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "TourAgency, Admin")]
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

        [HttpPost("Role")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateRole([FromBody] RoleRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if(role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(request.RoleName));
            }
            var user = await _userManager.FindByNameAsync(request.UserName);
            
            await _userManager.AddToRoleAsync(user, request.RoleName);
            return Ok();
        }
    }


    public class RoleRequest
    {
        public string RoleName { get; set; }
        public string UserName { get; set; }
    }
}
