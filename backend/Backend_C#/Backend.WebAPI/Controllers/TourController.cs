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
using System.Security.Claims;

namespace Backend.WebAPI.Controllers
{
    public class TourController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<TourController> _logger;

        public TourController(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger<TourController> logger) 
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TourDetailsVm>> GetTour(Guid id)
        {
            try
            {
                var query = new GetTourDetailsQuery
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


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTour([FromBody] CreateTourDto createTourDto)
        {
            try
            {
                //HttpContext.User.IsInRole();
                var command = _mapper.Map<CreateTourCommand>(createTourDto);
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
        [Authorize(Roles = "TourAgency")]
        public async Task<IActionResult> UpdateTour([FromBody] UpdateTourDto updateTourDto, Guid id)
        {
            try
            {
                var command = _mapper.Map<UpdateTourCommand>(updateTourDto);
                command.TourId = id;
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
        //[Authorize(Roles = "TourAgency, Admin")]
        public async Task<IActionResult> DeleteTour(Guid id)
        {
            try
            {
                var command = new DeleteTourCommand
                {
                    TourId = id
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

        [HttpPost]
        public async Task<ActionResult<TourListVm>> GetAllTours([FromBody] Filters filters)
        {
            try
            {
                var query = new GetTourListQuery
                {
                     MinPrice = filters.minPrice,
                    MaxPrice = filters.maxPrice
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<TourListVm>> GetUserTours()
        {
            try
            {
                //Получение Id через claim
                var UserId = Guid.Parse(HttpContext.User.FindFirstValue("UserId"));
                var query = new GetTourListQuery
                {
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

    public class Filters
    {
        public double? minPrice { get; set; }
        public double? maxPrice { get; set; }
    }
}
