namespace Backend.WebAPI.Middleware
{
    public static class CustomExeptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExeptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExeptionHandlerMiddleware>();
        }
    }
}
