using Microsoft.AspNetCore.Mvc;

namespace IActionResultProject.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            return File("/dummy.pdf", "application/pdf");
        }
    }
}
