using ModelValidations.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{
    //opt.ModelBinderProviders.Insert(0, new PersonModelBinderProvider());
});

builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
