using Backend.Application.Interfaces;
using Backend.Persistence.ModelsDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            //1\\
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddDbContext<TourDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddDbContext<PassportDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddDbContext<InternationalPassportDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            //Далее другие пов аналогии\\



            //1\\
            services.AddScoped<IUserDbContext>(provider =>
                provider.GetService<UserDbContext>());
            //Далее другие пов аналогии\\
            services.AddScoped<ITourDbContext>(provider =>
                provider.GetService<TourDbContext>());
            services.AddScoped<IOrderDbContext>(provider =>
                provider.GetService<OrderDbContext>());
            services.AddScoped<IPassportDbContext>(provider =>
                provider.GetService<PassportDbContext>());
            services.AddScoped<IInternationalPassportDbContext>(provider =>
                provider.GetService<InternationalPassportDbContext>());

            return services;
        }


    }
}
