using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}
