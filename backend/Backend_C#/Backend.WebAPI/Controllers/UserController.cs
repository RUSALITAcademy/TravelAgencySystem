using AutoMapper;
using Backend.Application.Models.Users.Commands.CreateUser;
using Backend.Application.Models.Users.Commands.DeleteUser;
using Backend.Application.Models.Users.Commands.UpdateUser;
using Backend.Application.Models.Users.Queries.GetUserDetails;
using Backend.WebAPI.Models.CreateDto;
using Backend.WebAPI.Models.UpdateDto;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        //!!! Авторизация в идеале, есть ограничения к методам на будущее [Authorize]


        //!!! Референс на всех userов. Если нужно будет, то надо реализовать GetUserListQuery для user в application


        //[HttpGet]
        //public async Task<ActionResult<UserListVm>> GetAllUsers()
        //{
        //    var query = new GetUserListQuery
        //    {
        //    };
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsVm>> GetUser(Guid id)
        {
            var query = new GetUserDetailsQuery
            {
                UserId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var UserId = await Mediator.Send(command);
            return Ok(UserId);
        }


        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto, Guid id)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.UserId = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand
            {
                UserId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }




    }
}
