using Autofac;
using Autofac.Extensions.DependencyInjection;
using DependencyInjectionServiceContracts;
using DependencyInjectionServices;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllersWithViews();

//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Scoped
//));

//builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Host.ConfigureContainer<ContainerBuilder>(containerbuilder =>
{
    containerbuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency(); // AddTransient
    //containerbuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope(); // AddScoped
    //containerbuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance(); // AddSingleton
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
