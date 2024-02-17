using MiddlewareExample.Middleware;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseLoginMiddleWare();

app.Run();
