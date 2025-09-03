using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//mideleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From Middleware 1");
    await next(context);
});

////middleware 2
//app.Use(async (HttpContext context,RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello again");
//    await next(context);
//}); 

app.UseMiddleware<MyCustomMiddleware>();

app.UseMyCustomMiddleware();

//middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("From Middleware 3");
});

app.Run();
