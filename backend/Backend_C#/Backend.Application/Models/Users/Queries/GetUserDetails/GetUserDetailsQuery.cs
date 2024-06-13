using MediatR;

namespace Backend.Application.Models.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery 
        : IRequest<UserDetailsVm>
    {
        public string UserId { get; set; }

    }
}
