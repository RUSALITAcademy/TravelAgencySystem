using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
    }
}
