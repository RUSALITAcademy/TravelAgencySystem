namespace Backend.WebAPI.Middleware
{
    using Backend.Persistence.ModelsDbContext;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    public class ClaimsTransformation : IClaimsTransformation
    {
        private readonly UserDbContext _dbcontext;

        public ClaimsTransformation(UserDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var user = _dbcontext.User.Single(x => x.NormalizedEmail == principal.Identity.Name.ToUpper());

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            var claimType = "UserId";
            if (!principal.HasClaim(claim => claim.Type == claimType))
            {
                claimsIdentity.AddClaim(new Claim(claimType, user.Id.ToString()));
            }

            principal.AddIdentity(claimsIdentity);
            return Task.FromResult(principal);
        }
    }
}
