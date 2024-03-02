using Microsoft.AspNetCore.Mvc;
using ModelValidations.CustomModelBinders;
using ModelValidations.Models;

namespace ModelValidations.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //[Bind(nameof(Person.PersonName), nameof(Person.Email),nameof(Person.Password), nameof(Person.ConfirmPassword))]
        //public IActionResult Index([FromBody][ModelBinder(BinderType = typeof(PersonModelBinder))] Person person)
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string userAgent)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }

            var dasd = Request.Headers["Key"];

            return Content($"{person},{userAgent}");
        }
    }
}
