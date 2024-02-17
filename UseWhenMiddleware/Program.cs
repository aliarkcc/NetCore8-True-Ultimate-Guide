var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello From Middleware Branch");
            await next(context);
        });
    });

app.Map("/map", config =>
{
    config.Run(async context =>
    {
        await context.Response.WriteAsync("Bu Run middleware den sonraski middleware calismayacak. Ve geriye donuyor..");
    });
});


app.Use(async (context, next) =>
{
    await context.Response.WriteAsync(Environment.NewLine + "Bu middleware Use middleware'idir pipelini going" + Environment.NewLine);
    await next(context);
    await context.Response.WriteAsync(Environment.NewLine + "Bu middleware Use middleware'idir pipelini incoming/n" + Environment.NewLine);
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Bu middleware2 den sonrasi calismayacak.");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from middleware at main chain");
});

app.Run();
