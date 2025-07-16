using Microsoft.EntityFrameworkCore;
using Session03;
using Session03.Middlewares;
using Session03.RouteConstraint;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RequestLogDbContext>(options =>
    options.UseSqlServer("Data Source=.;Initial Catalog=RequestLogger;Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddScoped<RequestLoggerService>();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("nationalcode", typeof(IranNationalCodeConstraint));
});

var app = builder.Build();


app.UseMiddleware<RequestLoggingMiddleware>();
app.MapGet("/", () => "Hello World!");

app.MapGet("/nationalCode/{code:nationalcode}", (string code) =>
{
    return Results.Ok($"کد ملی معتبر است: {code}");
});

app.Run();
