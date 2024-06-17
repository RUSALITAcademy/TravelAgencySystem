using System.Security.Claims;

namespace Backend.WebAPI.Middleware
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUserId(this ClaimsPrincipal user)
        {
            return user?.FindFirstValue("UserId");
        }
    }
}
