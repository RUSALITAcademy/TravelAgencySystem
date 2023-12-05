using MediatR;

namespace Backend.Application.Models.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery 
        : IRequest<UserDetailsVm>
    {
        public Guid UserId { get; set; }

    }
}
