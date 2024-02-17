using Microsoft.Extensions.Primitives;

namespace MiddlewareExample.Middleware
{
    public class LoginMiddleWare
    {
        private readonly RequestDelegate _next;

        public LoginMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/" && context.Request.Method == "POST")
            {
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                string? email = null, password = null;

                if (queryDict.ContainsKey("email"))
                {
                    email = Convert.ToString(queryDict["email"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'\n");
                }

                if (queryDict.ContainsKey("password"))
                {
                    password = Convert.ToString(queryDict["password"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'\n");
                }

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    string validEmail = "admin@example.com", validPassword = "admin1234";
                    bool isValidLogin;

                    if (email == validEmail && password == validPassword)
                    {
                        isValidLogin = true;
                    }
                    else
                    {
                        isValidLogin = false;
                    }

                    if (isValidLogin)
                    {
                        await context.Response.WriteAsync("Successful login\n");
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid login\n");
                    }

                }
            }
            else
            {
                await _next(context);
            }

        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleWare>();
        }
    }
}
