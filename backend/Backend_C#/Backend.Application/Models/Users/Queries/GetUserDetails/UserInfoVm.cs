using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Users.Queries.GetUserDetails
{
    public class UserInfoVm
    {
        public string Id { get; set; }
        public IList<string> Roles { get; set; }
    }
}
