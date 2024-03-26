using Autofac;
using DependencyInjectionServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILifetimeScope _lifeTimeScopeFactory;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, IServiceScopeFactory scopeFactory, ILifetimeScope lifeTimeScopeFactory)
        {
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _scopeFactory = scopeFactory;
            _lifeTimeScopeFactory = lifeTimeScopeFactory;
        }

        [Route("/")]
        public IActionResult Index(
            //[FromServices] ICitiesService _citiesService
            )
        {
            List<string> cities = _citiesService1.GetCities();

            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                //Inject CitiesService

                ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();

                //DB Work
                ViewBag.InstanceId_CitiesService_In_The_Scope = citiesService.ServiceInstanceId;

            }// end of scope; it calls CitiesService.Dispose()


            using (ILifetimeScope scope = _lifeTimeScopeFactory.BeginLifetimeScope())
            {
                //Inject CitiesService

                ICitiesService citiesService = scope.Resolve<ICitiesService>();

                //DB Work
                ViewBag.InstanceId_CitiesService_In_The_Scope = citiesService.ServiceInstanceId;

            }// end of scope; it calls CitiesService.Dispose()

            return View(cities);
        }
    }
}
