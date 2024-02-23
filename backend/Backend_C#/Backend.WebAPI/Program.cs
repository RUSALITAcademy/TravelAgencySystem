using Backend.Application;
using Backend.Application.Common.Mappings;
using Backend.Application.Interfaces;
using Backend.Persistence;
using Backend.WebAPI.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IUserDbContext).Assembly));
    config.AddProfile(new AssemblyMappingProfile(typeof(ITourDbContext).Assembly));
    config.AddProfile(new AssemblyMappingProfile(typeof(IOrderDbContext).Assembly));
});


//сам поставишь
builder.Services.AddSwaggerDocument();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
//МБ не надо
builder.Services.AddControllersWithViews();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


var app = builder.Build();


//
app.MapDefaultControllerRoute();

app.UseCustomExeptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
//Нужно для авторизации аутентификации
//app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();
//Swagger
app.UseOpenApi();
app.UseSwaggerUi3();
app.Run();