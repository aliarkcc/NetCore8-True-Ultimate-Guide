using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {
            ViewData["pageTitle"] = "Asp.Net Core Demo App";

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "Mali", DateOfBirth = Convert.ToDateTime("2002/01/02"), PersonGender = Gender.Male },
                new Person() { Name = "Cemre", DateOfBirth = Convert.ToDateTime("2001/04/04"), PersonGender = Gender.Female },
                new Person() { Name = "Sude", DateOfBirth = null, PersonGender = Gender.Female},
            };

            ViewData["people"] = people;
            ViewBag.people = people;

            return View(people); // Views/Home/Index.cshtml
            //return View("abc"); //abc.cshtml
            //return new ViewResult() { ViewName="abc",};
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            List<Person> people = new List<Person>()
            {
                new Person() { Name = "Mali", DateOfBirth = Convert.ToDateTime("2002/01/02"), PersonGender = Gender.Male },
                new Person() { Name = "Cemre", DateOfBirth = Convert.ToDateTime("2001/04/04"), PersonGender = Gender.Female },
                new Person() { Name = "Sude", DateOfBirth = null, PersonGender = Gender.Female},
            };

            var person = people.FirstOrDefault(p => p.Name == name);

            return View(person);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { Name = "Mali", DateOfBirth = Convert.ToDateTime("2002/01/02"), PersonGender = Gender.Male };

            Product product = new Product() { Id = 1, Name = "Air Conditioner" };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel()
            {
                PersonData = person,
                ProductData = product,
            };

            return View("PersonAndProduct",personAndProductWrapperModel);
        }

        [Route("/home/all-products")]
        public IActionResult All()
        {
            return View();
        }
    }
}
