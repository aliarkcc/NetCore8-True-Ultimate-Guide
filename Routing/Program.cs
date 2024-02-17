using Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthCustomConstraint));
});

var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    Endpoint endpoint = context.GetEndpoint();

//    if (endpoint != null)
//    {
//        await context.Response.WriteAsync($"Endpoint:{endpoint.DisplayName}\n");
//    }

//    await next(context);
//});

app.UseRouting();

//app.Use(async (context, next) =>
//{
//    Endpoint endpoint = context.GetEndpoint();

//    if (endpoint != null)
//    {
//        await context.Response.WriteAsync($"Endpoint:{endpoint.DisplayName}\n");
//    }

//    await next(context);
//});

//creating and endpoints
app.UseEndpoints(endpoints =>
{
    //add your endpoints
    endpoints.Map("map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map 1");
    });

    endpoints.Map("map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map 2");
    });

    endpoints.Map("files/{fileName:length(3,30)}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In Files - {fileName}.{extension}");
    });

    endpoints.Map("employee/profile/{EmployeeName:minlength(3):maxlength(8):alpha=mali}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);

        await context.Response.WriteAsync($"EmployeeName: {employeeName}");
    });

    endpoints.Map("products/details/{id:int?}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);

        await context.Response.WriteAsync($"Product Details : {id}");
    });


    //Eg: daily-digest-report/reportDate
    endpoints.Map("daily-digest-report/{reportDate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);

        await context.Response.WriteAsync($"In Daily Digest Report : {reportDate.ToShortDateString()}");
    });


    //Eg: cities/cityid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityid = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]));

        await context.Response.WriteAsync($"City Information : {cityid}");
    });

    //Eg: sales-report/2024/jan
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);

        string month = Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "apr" || month == "jul" || month == "may" || month == "jan" || month == "oct")
        {
            await context.Response.WriteAsync($"Sales Report : {year} , {month}");
        }
        else
        {
            await context.Response.WriteAsync($"{month} is not allowed for Sales Report");
        }

    });

    //Eg: sales-report/2024/jan
    endpoints.Map("sales-report/2024/jan", async context =>
    {
        await context.Response.WriteAsync($"Sales Report exclusiveliy for 2024 - jan");
    });
}); 


app.Run(async (context) =>
{
    await context.Response.WriteAsync($"No Request Matched {context.Request.Path}");
});

app.Run();
