using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> query = QueryHelpers.ParseQuery(body);

    if (query.ContainsKey("firstName"))
    {
        string firstName = query["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }

});

app.Run();
