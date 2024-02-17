using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ControllersProjecy.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //return Content("Hello From Index", "text/plain");

            //return new ContentResult()
            //{
            //    Content="Hello from Index",
            //    ContentType = "text/plain",
            //};

            return Content("<h1>Welcome</h1><br><h2>Hello From Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            ControllersProjecy.Models.Person person = new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mali",
                LastName = "Arkac",
                Age = 24
            };

            return Json(person);
            //return new JsonResult(person);
        }

        [Route("about")]
        public string About()
        {
            return "Hello From About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello From Contact";
        }
    }
}
